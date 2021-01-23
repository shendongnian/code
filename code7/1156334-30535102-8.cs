    public async Task LoadFile()
    {
        try
        {
            using (WebClient wc = new WebClient())
            {
                var bytes = await wc.DownloadDataTaskAsync(new Uri(string.Format("{0}/{1}", Settings1.Default.WebPhotosLocation, Path.GetFileName(f.FullName))), filePath);
                System.IO.File.WriteAllBytes(bytes); // Probably turn it into async too
            }                    
        }
        catch (Exception ex)
        {
            //Catch my error here and handle it (display message box)
        }
    }
