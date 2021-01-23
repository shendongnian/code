 	public static class ExceptionFileWriter
    {
        #region Property File Path
        static string FilePath
        {
            get
            {
                string path = string.Empty;
                var _fileName = "Fatal.txt";
	#if __IOS__
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Documents folder C:\ddddd
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder C:\dddd\...\library
                path = Path.Combine(libraryPath, _fileName); //c:\ddddd\...\library\NBCCSeva.db3
	#else
	#if __ANDROID__
                string dir = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Exception");
            if (Directory.Exists(dir))
                return Path.Combine(dir, _fileName);
            path= Path.Combine(Directory.CreateDirectory(dir).FullName, _fileName);
	#endif
	#endif
                return path;
            }
        }
        #endregion
        #region ToLog Exception
        public static void ToLogUnhandledException(this Exception exception)
        {
            try
            {
                var errorMessage = String.Format("Time: {0}\r\nError: Unhandled Exception\r\n{1}\n\n", DateTime.Now, string.IsNullOrEmpty(exception.StackTrace) ? exception.ToString() : exception.StackTrace);
                File.WriteAllText(FilePath, errorMessage);
            }
            catch (Exception ex)
            {
                // just suppress any error logging exceptions
            }
        }
        #endregion
    }
