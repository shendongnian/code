    public async void DownloadFile()
    {
        Response.Headers.Add("content-disposition", "attachment; filename=test.rar");
        byte[] arr = System.IO.File.ReadAllBytes(@"G:\test.rar");
        await Response.Body.WriteAsync(arr, 0, arr.Length);
    }
