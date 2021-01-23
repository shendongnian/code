    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "Extended file properties.";
            List<string> arrHeaders = new List<string>();
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder objFolder;
            objFolder = shell.NameSpace(@"C:\Users\Admin\Pictures\PBS Docs");
            for (int i = 0; i < short.MaxValue; i++)
            {
                string header = objFolder.GetDetailsOf(null, i);
                if (String.IsNullOrEmpty(header))
                    break;
                arrHeaders.Add(header);
            }
            foreach (Shell32.FolderItem2 item in objFolder.Items())
            {
                for (int i = 0; i < arrHeaders.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}: {2}", i, arrHeaders[i], objFolder.GetDetailsOf(item, i));
                }
            }
    }
