        public void Appen()
        {
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(path0save.Text, true))
            {
                 DirectoryInfo directory = new DirectoryInfo(path0tb.Text);
                 DirectoryInfo[] directory0Arr = directory.GetDirectories();
                 foreach (DirectoryInfo dir in directory0Arr)
                 {
                     // No need for those Convert.ToString. 
                     // The DirectoryInfo properties used are already strings.
                     file.Write(dir.Parent);
                     file.Write("   || ");
                     file.WriteLine(dir.Name);
                     file.WriteLine(dir.Root);
                     // or just in one line
                     //file.WriteLine(string.Concat(dir.Parent, 
                     //                      "   || ", 
                     //                      dir.Name, 
                     //                      Environment.NewLine,  
                     //                      dir.Root));  
   
                }
            }
        }
