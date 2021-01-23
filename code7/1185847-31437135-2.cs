        private void TestUnzip()
        {
            ZipArchive z = ZipFile.Open("zipfile.zip", ZipArchiveMode.Read);
            string LastFile = "lastFileName.ext";
            foreach (ZipArchiveEntry entry in z.Entries)
            {
                if (entry.Name != LastFile)
                {
                    entry.ExtractToFile(@"C:\somewhere\" + entry.FullName);
                }
            }
            foreach (ZipArchiveEntry entry in z.Entries)
            {
                if (entry.Name == LastFile)
                {
                    entry.ExtractToFile(@"C:\somewhere_else\" + entry.FullName);
                }
            }
            z.Dispose();
        }
