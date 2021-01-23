        private void TestUnzip()
        {
            ZipArchive z = ZipFile.Open("zipfile.zip", ZipArchiveMode.Read);
            string LastFile = "lastFileName.ext";
            int Count = z.Entries.Count() + 1;
            for (int i = 0; i < Count; i++)
            {
                if (i < Count && z.Entries[i].Name == LastFile)
                {
                    ZipFile.ExtractToDirectory(z.Entries[i].FullName, @"C:\somewhere_else");
                }
                else if (i < Count && z.Entries[i].Name != LastFile)
                {
                    ZipFile.ExtractToDirectory(z.Entries[i].FullName, @"C:\destination_directory");
                }
                // The loop will iterate a final time, but find nothing.
            }
            z.Dispose();
        }
