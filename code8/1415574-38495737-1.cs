    private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
            {
    
                FileInfo fileInfo = new FileInfo(e.FullPath);
                string strFileExt = fileInfo.Extension;
    
                // filter file types 
                if (Regex.IsMatch(strFileExt, @"\.png|\.jpg", RegexOptions.IgnoreCase))
                {
                    //here Process the image file 
                    try
                    {
                        using (Bitmap test = new Bitmap(Bitmap.FromFile(e.FullPath)))
                        {
                            //Do your code here.
                        }
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("File Error");
                    }
                }
              
                
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                fileSystemWatcher1.Path = @"C:\Users\Christlin\Desktop\res";
    
                //To Prevent duplicated calling of changed event
                fileSystemWatcher1.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
            }
