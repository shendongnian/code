    private int fireCounter = 0;
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            fireCounter++;
            if (fireCounter == 1)
            {
                delete();
                if (e.FullPath == @"C:\test.txt")
                {
                    Thread.Sleep(2000);
                    //I added Sleep for two seconds because without it sometimes it wont work
                    string textFilePath = @"C:\test.txt";
                    try
                    {
                        using (var streamReader = File.OpenText(textFilePath))
                        {
                            var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            foreach (var line in lines)
                            {
                                //Actions Here
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                fireCounter = 0;
            }
        }
