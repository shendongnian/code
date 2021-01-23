            foreach (var i in Enumerable.Range(0, file_name.Length))
            {
                string filename = file_name[i];
                string filesize = file_size[i];
                
                if (File.Exists(Directory.GetCurrentDirectory() + "\\dll\\" + filename))
                {
                    FileInfo f = new FileInfo(Directory.GetCurrentDirectory() + "\\dll\\" + filename);
                    string s1 = f.Length.ToString();
                    if (s1 != filesize)
                    {
                        MessageBox.Show(f.Name + "modified DLL file, please change it to original");
                    }
                }
            }
