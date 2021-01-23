    namespace LauncherWord
    {
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "";
            if (args.Length > 0)
                Path = args[0];
            OpenWord(Path);
          
        }
        protected static string OpenWord(string Path)
        {
            Word._Application application = null; ;
            Word._Document document = null; ;
            
            Object _Path = Path;
            try
            {
                application = new Word.Application();
                if (!string.IsNullOrEmpty(_Path.ToString()))
                    document = application.Documents.Open(ref _Path,Type.Missing,(object)false);
                application.Visible = true;
               
            }
            catch (Exception error)
            {
                try
                {
                    document.Close();
                }
                catch { }
                try
                {
                    application.Quit();
                }
                catch { }
                document = null;
                application = null;
                return error.Message + "innerExeption: " + error.InnerException.Message;
            }
            return "Succed";
        }
      }
    }
