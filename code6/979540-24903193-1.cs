    void previewSelectedPresentation(string presentationName)
    {
      previewImageList.Images.Clear();
      previewListView.Items.Clear();
                
      DirectoryInfo dir = new DirectoryInfo(@"E:\\test\\" + presentationName);
                
      foreach (FileInfo file in dir.GetFiles())
      {
        try
        {  
           // these three lines have changed
           Image slideImage = Image.FromFile(file.FullName);  // change 1
           this.previewImageList.Images.Add(slideImage);      // change 2
           slideImage.Dispose();                              // change 3
        }
        catch
        {
          Console.WriteLine("This is not an image file");
        }
      }
                
      for (int j = 0; j < this.previewImageList.Images.Count; j++)
      {
        ListViewItem item = new ListViewItem();
        item.ImageIndex = j;
        item.Text = (j + 1).ToString();                
        this.previewListView.Items.Add(item);
      }          
    }
