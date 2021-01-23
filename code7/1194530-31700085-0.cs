    public static class SilverlightTrace
    {
        public static void WriteLine(string message)
        {
            try
            {
                if (IsolatedStorageFile.IsEnabled)
                {
                    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        // Create trace file, if it doesn't exist
                        if(!store.FileExists("YourFileName.txt"))
                        {
                            var stream = store.CreateFile("YourFileName.txt");
                            stream.Close();
                        }
                        using (var writer = new StreamWriter(
                                            store.OpenFile("YourFileName.txt",
                                                           FileMode.Append,
                                                           FileAccess.Write)))
                        {
                            writer.WriteLine(message);
                            writer.Close();
                        }
                    }
                }      
            }
            catch(Exception e)
            {
                // Add some error handling here
            }
        }
    }
