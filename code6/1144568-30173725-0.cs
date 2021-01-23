     string path = Server.MapPath("~/App_Data/captions/" + entryId) + ".srt";
                using (FileStream f = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter s = new StreamWriter(f))
                    {
                        s.Write("someString");
                        f.Flush();
                        // Connecting to API and uploading the file
                    }
                }
