        public static void WriteLine(System.IO.FileStream fileStream, string str) {
            try {
                LockFile(fileStream);
                fileStream.Seek(0, System.IO.SeekOrigin.End);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str + "\r\n");
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
            } finally {
                UnlockFile(fileStream);
            }
        }
        public static void LockFile(System.IO.FileStream fileStream) {
            bool notlocked = true;
            while (notlocked) {
                try { fileStream.Lock(0, long.MaxValue); notlocked = false; } catch (Exception Ex) { ReaperCore.CoreLogging.ExceptionDescription(Ex); }
            }
        }
        public static void UnlockFile(System.IO.FileStream fileStream) { fileStream.Unlock(0, long.MaxValue); }
