    namespace WebFormsApp
    {
        public class Directory
        {
            // the directory names like First Directory
            public string DirectoryName { get; set; }
            // the content that comes under header tag
            public string HeaderText { get; set; }
            // the content that comes under p tag
            public string InfoText { get; set; }
        }
        public class DirectoryFile
        {
            // file name
            public string FileName { get; set; }
            // download url
            public string Url { get; set; }
        }
    }
