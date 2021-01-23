     ArrayList files = new ArrayList();
     files.AddRange(Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories));
            foreach (DataRow row in tableFiles.Rows)
            {
                for (int i = 0; i < files.Count; i++)
                    if (files[i].ToString().EndsWith(row[0].ToString()))
                    {
                        files.RemoveAt(i);
                        break;
                    }
            }
