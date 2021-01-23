     public string MergeFiles(string folder)
        {
            using (ZipFile zip = new ZipFile(folder))
            {
                string[] fileEntries = Directory.GetFiles(folder);
                foreach (string f in fileEntries)
                {
                    string path = Path.GetDirectoryName(f.Substring(folder.Length));
                        zip.AddFile(f, path);
                }
                zip.Save(folder + "\\files.zip");
            }
            return folder+"\\files.zip";
        }
