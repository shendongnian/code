    class Program {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetFileTime(SafeFileHandle hFile, ref long lpCreationTime, ref long lpLastAccessTime, ref long lpLastWriteTime);
    
        static void Main(string[] args) {
            var filePath = "test.txt";
            long when = DateTime.Now.AddDays(10).ToFileTime();
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite)) {
                if (!SetFileTime(fileStream.SafeFileHandle, ref when, ref when, ref when)) {
                    throw new Win32Exception();
                }
                var bytes = Encoding.ASCII.GetBytes("Hello fail.");
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
