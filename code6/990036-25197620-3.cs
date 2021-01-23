    public async Task GetImageAndDoStuff()
    {
       Stream imageStream = await GetStreamAsync();
       using (Bitmap bitmap = new Bitmap(Image.FromStream(imageStream)))
       {
        
       }
    }
