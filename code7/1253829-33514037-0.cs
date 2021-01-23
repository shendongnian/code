    /// <summary>
    /// Intermediate buffer to be used as out string parameter in interop scenario
    /// </summary>
    /// <remarks>
    /// It's not writeable or initializable with string at caller site to exactly match
    /// task of retrieve string data from called site.
    /// Can work both with ANSI and Unicode (16/32), so with char* and wchar_t* c++ buffers
    /// Can be used as Long-Live buffer 
    /// </remarks>
    /// <example>
    /// /// we not require to use StringBuilder and set CharSet explicitly
    /// [DllImport(LibraryName, CallingConvention = CallingConvention.StdCall)]
    /// public static extern void setBuffer(IntPtr sb, int capacity);
    /// [DllImport(LibraryName, CallingConvention = CallingConvention.StdCall)]
    /// public static extern void doSomethingThatWritesToBuffer();
    /// using (var buffer = new OutStringBuffer(100)){
    ///     setBuffer(buffer.GetIntPtr(), buffer.GetCapacity());
    ///     doSomethingThatWritesToBuffer();
    ///     Console.WriteLine(buffer.ToString());
    /// }
    /// </example>
    public class OutStringBuffer : IDisposable { // it must be disposal while it allocates unmanaged memory
        public const int ANSI_SIZE = 1;
        public const int UTF16_SIZE = 2;
        public const int UTF32_SIZE = 4;
        // be default most implementation of c++ uses UTF-16 for wchar_t and .net is Unicode-16 based system by default
        // if you use C++ implementation with 4-byte wide char u can define WCHAR_UTF32 globally
    #if WCHAR_UTF32
        public const int DEFAULT_WCHARSIZE = UTF32_SIZE;
    #else
        public const int DEFAULT_WCHARSIZE = UTF16_SIZE;
    #endif
        /// <summary>
        /// Initialize buffer of given size (in chars) with given char_size
        /// </summary>
        /// <param name="size">Size of buffer in chars (5 for "Hello")</param>
        /// <param name="charsize">Size of used char (Unicode in platform C++ by default) 1(ANSI) 2(UTF-16) or 4(UTF-32)</param>
        public OutStringBuffer(int size, int charsize = DEFAULT_WCHARSIZE)
        {
            if (size <= 0)
            {
                throw new ArgumentException(INVALID_SIZE_MESSAGE, nameof(size));
            }
            if (!(charsize == ANSI_SIZE || charsize == UTF16_SIZE || charsize == UTF32_SIZE))
            {
                throw new ArgumentException(INVALID_CHARSIZE_MESSAGE, nameof(charsize));
            }
            _size = size;
            _charsize = charsize;
        }
        private readonly int _size = 0;
        private IntPtr _ptr = IntPtr.Zero;
        private bool _disposed = false;
        private readonly int _charsize;
        /// <summary>
         /// Retruns given max size in chars
         /// </summary>
         /// <returns>Max size of out string</returns>
        public int GetCapacity() {
            return _size;
        }
        private const string INVALID_SIZE_MESSAGE = "Size must be greater than zero";
        private const string INVALID_CHARSIZE_MESSAGE = "Char size must be 1 for ANSI or 2 for UTF-16 (MC++ wchar_t) or 4 for UTF-32";
        /// <summary>
        /// Initializes global IntPtr for string buffer, that can be used in Interop
        /// </summary>
        /// <returns>Pointer to char* or wchar_t* with given size</returns>
        /// <remarks>It's lazy - if not called - OutStringBuffer will not allocate memory</remarks>
        public IntPtr GetIntPtr() {
            if (_disposed) {
                throw new ObjectDisposedException("this buffer was disposed");
            }
            if (_ptr == IntPtr.Zero) {
                _ptr = Marshal.AllocHGlobal((_size + 1) * _charsize); // correct size for wchar_t* (null-terminated)
                // we require to initialize first char with \0 while if we not - it can cause garbage at start of string
                if (_charsize == ANSI_SIZE) {
                    Marshal.WriteByte(_ptr,0);
                }else if (_charsize == UTF16_SIZE) {
                    Marshal.WriteInt16(_ptr, 0);
                }
                else {
                    Marshal.WriteInt32(_ptr, 0);
                }
               
            }
            return _ptr;
        }
        
        /// <summary>
        /// Read current string value from unmanaged buffer
        /// </summary>
        /// <returns>current string data from buffer</returns>
        public override string ToString() {
            if (_ptr == IntPtr.Zero) {
                return string.Empty;
            }
            if (_charsize == ANSI_SIZE) {
                return Marshal.PtrToStringAnsi(_ptr) ?? string.Empty;
            }
            if (_charsize == UTF16_SIZE) {
                return Marshal.PtrToStringUni(_ptr) ?? string.Empty;
            }
            
            //don't found more efficient way to translate UTF-32 IntPtr to string 
            var b = new StringBuilder();
            for (var i = 0; i < _size; i++) {
                var _p = _ptr + i*UTF32_SIZE;
                var c = Marshal.ReadInt32(_p);
                if(c==0)break;
                b.Append(char.ConvertFromUtf32(c));
            }
            return b.ToString();
        }
        public void Dispose() {
            _disposed = true;
            if (_ptr != IntPtr.Zero) {
                Marshal.FreeHGlobal(_ptr);
            }
        }
        //while it can be used outside "using" block we force dispose at GC too
        ~OutStringBuffer() {
            if (!_disposed) {
                Dispose();
            }
        }
    }
