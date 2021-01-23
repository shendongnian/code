        private void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception ex)
                {
                    //Could not delete the file, wait and try again
                    try
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        File.Delete(fileName);
                    }
                    catch
                    {
                        //Could not delete the file still
                    }
                }
            }
        }
