    private void CopyToDir(string filename)
            {
                //  txtBox.Text = "Hello World";  
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
                Console.WriteLine(path);
                //Check the directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
    
                try
                {
                    FileInfo fi = new FileInfo(filename);
                    if (!File.Exists(System.IO.Path.Combine(path, fi.Name)))
                    {
                        File.Copy(fi.FullName, System.IO.Path.Combine(path, fi.Name));
                    }
    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    
                //Loads next Assembly 
                _Plugins = new Dictionary<string, IPlugin>();
            }
