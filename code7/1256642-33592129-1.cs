    private async void Button1_Click(...)  
    { 
       var pages = await GetPages(...); 
       // update the UI here
    }
    public Task<List<List<string>>> GetPages(string url, int num_pages)
    {
        ...
        return task;
    }
