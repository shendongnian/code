    public static void ExecuteBackupAsZip(string SourcePath, string DestinationPath)
            {
                using (var zip = new Ionic.Zip.ZipFile())
                {
                    try
                    {
                        zip.AddDirectory(SourcePath);
                        zip.Save(DestinationPath);
                    }
                    catch { Console.WriteLine("Failed to execute backup"); }
                }
            }
