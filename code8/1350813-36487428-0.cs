        static void Main(string[] args)
        {
            var wmp = new WMPLib.WindowsMediaPlayer();
            wmp.URL = CreateTempFileFromResource("ConsoleApplication1.mp3.somefile.mp3");
            Console.ReadKey();
        }
        private static string CreateTempFileFromResource(string resourceName)
        {
            var tempFilePath = Path.GetTempFileName() + Path.GetExtension(resourceName);
            using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (var tempFileStream = new FileStream(tempFilePath, FileMode.Create))
            {
                resourceStream.CopyTo(tempFileStream);
            }
            return tempFilePath;
        }
