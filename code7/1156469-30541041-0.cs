    foreach (var filePath in filePaths)
        {
            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    var position = entry.Name.IndexOf(txtSearch, StringComparison.InvariantCultureIgnoreCase);
                    if (position > -1)
                    {
                        listView1.Items.Add(entry.Name);
                    }
                    else
                    {
                        MessageBox.Show("FILE NOT FOUND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
