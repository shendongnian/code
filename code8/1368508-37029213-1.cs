    {
            string[] files = Directory.GetFiles(destination_path);
            foreach (string filename in files)
            {
                if (File.Exists(destination_path + "\\" + filename))
                {
                    try
                    {
                        File.Delete(destination_path + "\\" + filename);
                    }
                    catch (Exception ex)
                    {
                        logFile.WriteLine("The deletion process failed: {0}", ex.Message);
                    }
                }
            }
        }
