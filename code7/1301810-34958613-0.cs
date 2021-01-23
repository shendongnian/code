    string BaseFolder = @"folderLocation here";
    foreach (ListItem item in ListBoxArchive.Items)
       {
           if (item.Selected)
           {
               string fileLPath = Path.Combine(BaseFolder,item.ToString());
               File.Delete(filePath);
           }
       }
       //Rebind the List here
