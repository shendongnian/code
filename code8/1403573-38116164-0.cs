        public void Appen()
        {
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(path0save.Text, true))
            {
                 DirectoryInfo directory = new DirectoryInfo(path0tb.Text);
                 DirectoryInfo[] directory0Arr = directory.GetDirectories();
                 foreach (DirectoryInfo dir in directory0Arr)
                 {
                     String Parent = Convert.ToString(dir.Parent);
                     String Name = Convert.ToString(dir.Name);
                     String Root = Convert.ToString(dir.Root);
                     file.Write(Parent);
                     file.Write("   || ");
                     file.WriteLine(Name);
                     file.WriteLine(Root);
  
   
                }
            }
        }
