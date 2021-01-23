    private void getAllFiles(string path)
            {
                var dropCon = DatabaseDropbox.Instance();
                if (dropCon.IsConnect())
                {
                    ICloudDirectoryEntry folder = dropCon.DropboxStorage.GetFolder(path);
    
                    foreach (ICloudFileSystemEntry fsentry in folder)
                    {
                        if (fsentry is ICloudDirectoryEntry) // IF FOLDER
                        {
                            var mpath = path + "/" + fsentry.Name;
                            getAllFiles(mpath);
                        }
                        else // IF FILE
                        {
                            Console.WriteLine(path + " " + fsentry.Name);
                            ListViewItem lvi = new ListViewItem(fsentry.Name);
                            lvi.SubItems.Add(path);
                            listViewFolders.Items.Add(lvi);
                        }         
                    }
                }                   
            }
