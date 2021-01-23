        private void button1_Click(object sender, EventArgs e)
        {   // last 2 weeks only:
            DateTime dt = DateTime.Now.AddDays(-14);  // use your own way to set it!
            string imagesPath = @"D:\scrape\SOusers";
            string[] extensions = new[] { ".jpg", ".jpeg", ".png" };
            var allfiles = Directory.GetFiles(imagesPath);
            List<FileInfo> files = new List<FileInfo>();
            foreach(string f in allfiles) files.Add(new FileInfo(f));
            var filesSorted = files.Where(f => extensions.Contains( f.Extension.ToLower()))
                                   .Where(f => f.CreationTime < dt)
                                   .OrderByDescending(f => f.CreationTime);
            this.imageList1.ImageSize = new Size(256, 250);
            this.imageList1.ColorDepth = ColorDepth.Depth32Bit;
            foreach (FileInfo fileInfo in filesSorted)
            {
                try {
                      this.imageList1.Images.Add(fileInfo.Name,
                                               Image.FromFile(fileInfo.FullName));
                }
                catch {
                        Console.WriteLine(fileInfo.FullName + "  is is not a valid image.");
                }
            }
            lstView_un.View = View.LargeIcon;
            lstView_un.LargeImageList = this.imageList1;
            lstView_un.Items.Clear();
            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                item.Text = imageList1.Images.Keys[j].ToString();
                this.lstView_un.Items.Add(item);
            }             
       }
