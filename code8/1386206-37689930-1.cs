    public class InteropHelper
    {
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);
    
        public static readonly int AVERROR_EOF = -GetTag("EOF ");
        public static readonly int AVERROR_UNKNOWN = -GetTag("UNKN");
        public static readonly int AVFMT_GLOBALHEADER = 0x0040;
        public static readonly int AVFMT_NOFILE = 0x0001;
        public static readonly int AVIO_FLAG_WRITE = 2;
        public static readonly int AV_CODEC_FLAG_GLOBAL_HEADER = (1 << 22);
        public static readonly int AV_ROUND_ZERO = 0;
        public static readonly int AV_ROUND_INF = 1;
        public static readonly int AV_ROUND_DOWN = 2;
        public static readonly int AV_ROUND_UP = 3;
        public static readonly int AV_ROUND_PASS_MINMAX = 8192;
        public static readonly int AV_ROUND_NEAR_INF = 5;
        public static readonly int AVFMT_NOTIMESTAMPS = 0x0080;
    
        public static unsafe void Check(void* ptr)
        {
            if (ptr != null)
                return;
    
            const int ENOMEM = 12;
            Check(-ENOMEM);
        }
    
        public static unsafe void Check(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
                return;
    
            Check((void*)null);
        }
    
        // example: "\x00F8FIL" is "Filter not found" (check libavutil/error.h)
        public static void CheckTag(string tag)
        {
            Check(-GetTag(tag));
        }
    
        public static int GetTag(string tag)
        {
            var bytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                bytes[i] = (byte)tag[i];
            }
            return BitConverter.ToInt32(bytes, 0);
        }
    
        public static void Check(int res)
        {
            if (res >= 0)
                return;
    
            string err = "ffmpeg error " + res;
            string text = GetErrorText(res);
            if (!string.IsNullOrWhiteSpace(text))
            {
                err += ": " + text;
            }
            throw new Exception(err);
        }
    
        public static string GetErrorText(int res)
        {
            IntPtr err = Marshal.AllocHGlobal(256);
            try
            {
                ffmpeg.av_strerror(res, err, 256);
                return Marshal.PtrToStringAnsi(err);
            }
            finally
            {
                Marshal.FreeHGlobal(err);
            }
        }
    }
