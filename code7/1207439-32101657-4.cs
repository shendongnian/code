    public class DocumentViewModel 
    {
        private string documentPath;
        public string DocumentPath
        {
            get { return documentPath; }
            set { SetProperty(ref documentPath, value); }
        }
    }
