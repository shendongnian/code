            Dictionary<string, string> FileNameAndSizes = new Dictionary<string, string>();
            
            FileNameAndSizes.Add("file1.dll", "17662");
            FileNameAndSizes.Add("file2.dll", "19019");
            foreach (var item in FileNameAndSizes)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\dll\\" + item.Key))
                {
                    FileInfo f = new FileInfo(Directory.GetCurrentDirectory() + "\\dll\\" + item.Key);
                    string s1 = f.Length.ToString();
                    if (s1 != item.Value)
                    {
                        MessageBox.Show(f.Name + "modified DLL file, please change it to original");
                    }
                }
            }
