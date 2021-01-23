    string[] directories = Directory.GetDirectories(@"D:\descargas");
    foreach (string dir in directories)
    {
         string[] subdir = Directory.GetDirectories(dir);
         this.contextMenuStrip1.Items.Add(dir);
         foreach(string sub in subdir)
         {
              (contextMenuStrip1.Items[contextMenuStrip1.Items.Count-1] as ToolStripMenuItem).DropDownItems.Add(sub);
         }
         string[] files = Directory.GetFiles(dir);
         foreach(string file in files)
         {
              this.contextMenuStrip1.Items.Add(file);
         }
    }
