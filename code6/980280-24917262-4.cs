    class DocumentManager
    {
        public string filePath;
        public string openfile()
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            bool? result = open.ShowDialog();
            if (result == true) { filePath = open.FileName; }
            else { filePath = "Nothing Opened"; }
            return filePath;
        }
    }
