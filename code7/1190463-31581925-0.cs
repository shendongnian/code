        private void BatchReplace()
        {
            string sourceFolder = FilePath.Text;
            string searchWord = Searchbar.Text;
    
            AddFileNamesToList(sourceFolder);
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please Check the files you want to rename");
                return;
            }
            
                    for (int x = 0; x < listView1.CheckedItems.Count; x++)
                    {
                        var file = listView1.CheckedItems[x].tag.ToString()
                            try
                            {
                                DialogResult dialogResult = MessageBox.Show("Are you sure you want to replace \"" + Searchbar.Text + "\" with \"" + Replacebar.Text + "\"?", "WARNING!", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    StreamReader reader = new StreamReader(file);
                                    string content = reader.ReadToEnd();
                                    reader.Close();
    
                                    content = Regex.Replace(content, Searchbar.Text, Replacebar.Text);
                                    StreamWriter writer = new StreamWriter(file);
                                    writer.Write(content); 
                                    writer.Close();
                                }
                            }
                            catch
                            { 
                            } 
                        }
                    }
                }
            }
        }
