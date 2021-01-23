    private static async Task DownloadFile(string HostPath,string Filepath)
    {
        WebClient webClient = new WebClient();
    
       
        await webClient.DownloadFileAsync(new Uri(HostPath), Filepath);
    }
    // usage
    private async void SomeMethod(){
       await DownloadFile("url", "path local');
       // it's ready for use. 
       ReadFile("path local)// File is already downloaded at this point
    }
