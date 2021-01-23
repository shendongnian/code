        private void TestUnzip_Foreach()
        {
            using (ZipArchive z = ZipFile.Open("zipfile.zip", ZipArchiveMode.Read))
            {
                string LastFile = "lastFileName.ext";
                int curPos = 0;
                int lastFilePosition = 0;
                foreach (ZipArchiveEntry entry in z.Entries)
                {
                    if (entry.Name != LastFile)
                    {
                        entry.ExtractToFile(@"C:\somewhere\" + entry.FullName);
                    }
                    else
                    {
                        lastFilePosition = curPos;
                    }
                    curPos++;
                }
                z.Entries[lastFilePosition].ExtractToFile(@"C:\somewhere_else\" + LastFile);
            }
        }
