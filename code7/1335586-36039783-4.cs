        static void Main(string[] args)
        {
            var appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(appPath));
        }
