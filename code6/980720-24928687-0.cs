    public static class Logger
    {
        public static void Log(string format, params object[] args)
        {
            using (var streamWriter = new StreamWriter("C:\\TEST\\logfiles\\Test_Plugin.txt", true))
            {
                streamWriter.WriteLine("{0}: {1}", DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"), string.Format(format, args));
            }
        }
    }
