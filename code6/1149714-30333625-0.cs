    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    namespace StreamReaderOverride
    {
        public class CustomStreamReader : StreamReader
        {
            private int charPos;
            private int charLen;
            private int byteLen;
            private Encoding encoding;
            private bool _isBlocked;
            private byte[] byteBuffer;
            private Decoder decoder;
            private int bytePos;
            private bool _checkPreamble;
            private bool _detectEncoding;
            private Stream stream;
            private volatile Task _asyncReadTask;
            private char[] charBuffer;
            private byte[] _preamble;
            private bool _closable;
            public bool EndOfStream;
            private int _maxCharsPerBuffer;
            public CustomStreamReader(Stream stream): this(stream, Encoding.UTF8, true, DefaultBufferSize, false)
            {
            
            }
            public CustomStreamReader(string path): this(path, Encoding.UTF8, true, DefaultBufferSize, false)
            {
            }
            public CustomStreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen): base(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks, bufferSize, false)
            {
	            if (stream == null || encoding == null)
	            {
		            throw new ArgumentNullException((stream == null) ? "stream" : "encoding");
	            }
	            if (!stream.CanRead)
	            {
		            throw new ArgumentException(GetResourceString("Argument_StreamNotReadable"));
	            }
	            if (bufferSize <= 0)
	            {
		            throw new ArgumentOutOfRangeException("bufferSize", GetResourceString("ArgumentOutOfRange_NeedPosNum"));
	            }
	            this.Init(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            }
            internal CustomStreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool checkHost): base(path, Encoding.UTF8, detectEncodingFromByteOrderMarks, bufferSize)
            {
	            if (path == null || encoding == null)
	            {
		            throw new ArgumentNullException((path == null) ? "path" : "encoding");
	            }
	            if (path.Length == 0)
	            {
		            throw new ArgumentException(GetResourceString("Argument_EmptyPath"));
	            }
	            if (bufferSize <= 0)
	            {
		            throw new ArgumentOutOfRangeException("bufferSize", GetResourceString("ArgumentOutOfRange_NeedPosNum"));
	            }
	            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, false);
	            this.Init(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, false);
            }
            internal static int DefaultBufferSize
            {
                get
                {
                    return 1024;
                }
            }
            private void Init(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
            {
                this.stream = stream;
                this.encoding = encoding;
                this.decoder = encoding.GetDecoder();
                if (bufferSize < 128)
                {
                    bufferSize = 128;
                }
                this.byteBuffer = new byte[bufferSize];
                this._maxCharsPerBuffer = encoding.GetMaxCharCount(bufferSize);
                this.charBuffer = new char[this._maxCharsPerBuffer];
                this.byteLen = 0;
                this.bytePos = 0;
                this._detectEncoding = detectEncodingFromByteOrderMarks;
                this._preamble = encoding.GetPreamble();
                this._checkPreamble = (this._preamble.Length > 0);
                this._isBlocked = false;
                this._closable = !leaveOpen;
            }
            private void CheckAsyncTaskInProgress()
            {
                Task asyncReadTask = this._asyncReadTask;
                if (asyncReadTask != null && !asyncReadTask.IsCompleted)
                {
                    throw new InvalidOperationException(GetResourceString("InvalidOperation_AsyncIOInProgress"));
                }
            }
            public string ReadLineOrNullString()
            {            
                if (this.stream == null)
                {
                    return null;
                }
                this.CheckAsyncTaskInProgress();
                if (this.charPos == this.charLen && this.ReadBuffer() == 0)
                {
                    return null;
                }
                StringBuilder stringBuilder = null;
                int num;
                char c;
                while (true)
                {
                    num = this.charPos;
                    do
                    {
                        c = this.charBuffer[num];
                        if (c == '\r' || c == '\n' || c == '\0')
                        {
                            goto IL_4A;
                        }
                    
                        num++;
                    }
                    while (num < this.charLen);
                    num = this.charLen - this.charPos;
                    if (stringBuilder == null)
                    {
                        stringBuilder = new StringBuilder(num + 80);
                    }
                    stringBuilder.Append(this.charBuffer, this.charPos, num);
                    if (this.ReadBuffer() <= 0)
                    {
                        goto Block_11;
                    }
                }
            IL_4A:
                string result;
                if (stringBuilder != null)
                {
                    stringBuilder.Append(this.charBuffer, this.charPos, num - this.charPos);
                    result = stringBuilder.ToString();
                }
                else
                {
                    result = new string(this.charBuffer, this.charPos, num - this.charPos);
                }
                this.charPos = num + 1;
                if ((c == '\r' && (this.charPos < this.charLen || this.ReadBuffer() > 0) && this.charBuffer[this.charPos] == '\n'))
                {
                    this.charPos++;
                }
                if (this.charPos >= this.charLen)
                {
                    this.EndOfStream = true;
                }
                return result;
            Block_11:
                return stringBuilder.ToString();
            }
            internal virtual int ReadBuffer()
            {
                this.charLen = 0;
                this.charPos = 0;
                if (!this._checkPreamble)
                {
                    this.byteLen = 0;
                }
                while (true)
                {
                    if (this._checkPreamble)
                    {
                        int num = this.stream.Read(this.byteBuffer, this.bytePos, this.byteBuffer.Length - this.bytePos);
                        if (num == 0)
                        {
                            break;
                        }
                        this.byteLen += num;
                    }
                    else
                    {
                        this.byteLen = this.stream.Read(this.byteBuffer, 0, this.byteBuffer.Length);
                        if (this.byteLen == 0)
                        {
                            goto Block_5;
                        }
                    }
                    this._isBlocked = (this.byteLen < this.byteBuffer.Length);
                    if (!this.IsPreamble())
                    {
                        if (this._detectEncoding && this.byteLen >= 2)
                        {
                            this.DetectEncoding();
                        }
                        this.charLen += this.decoder.GetChars(this.byteBuffer, 0, this.byteLen, this.charBuffer, this.charLen);
                    }
                    if (this.charLen != 0)
                    {
                        goto Block_9;
                    }
                }
                if (this.byteLen > 0)
                {
                    this.charLen += this.decoder.GetChars(this.byteBuffer, 0, this.byteLen, this.charBuffer, this.charLen);
                    this.bytePos = (this.byteLen = 0);
                }
                return this.charLen;
            Block_5:
                return this.charLen;
            Block_9:
                return this.charLen;
            }
            private bool IsPreamble()
            {
                if (!this._checkPreamble)
                {
                    return this._checkPreamble;
                }
                int num = (this.byteLen >= this._preamble.Length) ? (this._preamble.Length - this.bytePos) : (this.byteLen - this.bytePos);
                int i = 0;
                while (i < num)
                {
                    if (this.byteBuffer[this.bytePos] != this._preamble[this.bytePos])
                    {
                        this.bytePos = 0;
                        this._checkPreamble = false;
                        break;
                    }
                    i++;
                    this.bytePos++;
                }
                if (this._checkPreamble && this.bytePos == this._preamble.Length)
                {
                    this.CompressBuffer(this._preamble.Length);
                    this.bytePos = 0;
                    this._checkPreamble = false;
                    this._detectEncoding = false;
                }
                return this._checkPreamble;
            }
            private void DetectEncoding()
            {
                if (this.byteLen < 2)
                {
                    return;
                }
                this._detectEncoding = false;
                bool flag = false;
                if (this.byteBuffer[0] == 254 && this.byteBuffer[1] == 255)
                {
                    this.encoding = new UnicodeEncoding(true, true);
                    this.CompressBuffer(2);
                    flag = true;
                }
                else if (this.byteBuffer[0] == 255 && this.byteBuffer[1] == 254)
                {
                    if (this.byteLen < 4 || this.byteBuffer[2] != 0 || this.byteBuffer[3] != 0)
                    {
                        this.encoding = new UnicodeEncoding(false, true);
                        this.CompressBuffer(2);
                        flag = true;
                    }
                    else
                    {
                        this.encoding = new UTF32Encoding(false, true);
                        this.CompressBuffer(4);
                        flag = true;
                    }
                }
                else if (this.byteLen >= 3 && this.byteBuffer[0] == 239 && this.byteBuffer[1] == 187 && this.byteBuffer[2] == 191)
                {
                    this.encoding = Encoding.UTF8;
                    this.CompressBuffer(3);
                    flag = true;
                }
                else if (this.byteLen >= 4 && this.byteBuffer[0] == 0 && this.byteBuffer[1] == 0 && this.byteBuffer[2] == 254 && this.byteBuffer[3] == 255)
                {
                    this.encoding = new UTF32Encoding(true, true);
                    this.CompressBuffer(4);
                    flag = true;
                }
                else if (this.byteLen == 2)
                {
                    this._detectEncoding = true;
                }
                if (flag)
                {
                    this.decoder = this.encoding.GetDecoder();
                    this._maxCharsPerBuffer = this.encoding.GetMaxCharCount(this.byteBuffer.Length);
                    this.charBuffer = new char[this._maxCharsPerBuffer];
                }
            }
            private void CompressBuffer(int n)
            {
                InternalBlockCopy(this.byteBuffer, n, this.byteBuffer, 0, this.byteLen - n);
                this.byteLen -= n;
            }
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries"), SecuritySafeCritical]
            internal static string GetResourceString(string key)
            {
                return GetResourceFromDefault(key);
            }
            [SecurityCritical]
            [MethodImpl(MethodImplOptions.InternalCall)]
            internal static extern string GetResourceFromDefault(string key);
            [SecuritySafeCritical]
            [MethodImpl(MethodImplOptions.InternalCall)]
            internal static extern void InternalBlockCopy(Array src, int srcOffsetBytes, Array dst, int dstOffsetBytes, int byteCount);
        }
    }
