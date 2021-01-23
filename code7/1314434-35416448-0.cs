        public const string databaseName = "Sample.db";
        public static async Task<string> DatabaseExists(Context context)
        {
            return await Task.Run(delegate
            {
                /**
                this code is temporary
                **/
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", databaseName);
                //File.Delete(dbPath);
                // Check if your DB has already been extracted.
                if (!File.Exists(dbPath))
                {
                    using (BinaryReader br = new BinaryReader(context.Assets.Open(databaseName)))
                    {
                        using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int len = 0;
                            while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                bw.Write(buffer, 0, len);
                            }
                        }
                        return "success";
                    }
                }
                else
                {
                }
                return "success";
            });
        }
