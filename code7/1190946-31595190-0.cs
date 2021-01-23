            foreach (string str in <X>)
            {
                var nameCount = zip.Count(entry => entry.FileName == str);
                if (nameCount>0)
                {
                    zip.AddFile(str + string.Format("({0})",nameCount), "");
                }
                else
                {
                    zip.AddFile(str, "");
                }
            }
