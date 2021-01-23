    public void Post()
    {
                using (var fileStream = File.Create("C:\\NewFile.jpg"))
                {
                    using (MemoryStream tempStream = new MemoryStream())
                    {
                        var task = this.Request.Content.CopyToAsync(tempStream);
                        task.Wait();
    
                        tempStream.Seek(0, SeekOrigin.Begin);
                        tempStream.CopyTo(fileStream);
                        tempStream.Close();
                    }
                    
                }
     }
