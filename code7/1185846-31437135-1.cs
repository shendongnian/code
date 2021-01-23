        private void TestUnzip()
        {
            ZipArchive z = ZipFile.Open("zipfile.zip", ZipArchiveMode.Read);
            string LastFile = "lastFileName.ext";
            foreach (ZipArchiveEntry entry in z.Entries)
            {
                if (entry.Name != LastFile)
                {
                    z.ExtractToDirectory(@"C:\destination_directory\");
                }
            }
            z.ExtractToDirectory(@"C:\somewhere_else\right_here\");
            z.Dispose();
        }
