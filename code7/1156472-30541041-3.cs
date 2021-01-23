    foreach (var filePath in filePaths)
        {
            int count=0;
            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    var position = entry.Name.IndexOf(txtSearch, StringComparison.InvariantCultureIgnoreCase);
                    if (position > -1)
                    {
                        listView1.Items.Add(entry.Name);
                        count++;
                    }
                    
                }
                if(count==0)
                {
                     MessageBox.Show("FILE "+filepath+ "NOT FOUND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
