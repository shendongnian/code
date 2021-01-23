    GetButton.Click += async (sender, e) => {
    
        Task<int> sizeTask = DownloadHomepage();
    
        ResultTextView.Text = "loading...";
        ResultEditText.Text = "loading...\n";
    
        // await! control returns to the caller 
        // "See await"
        var intResult = await sizeTask
    
        // when the Task<int> returns, the value is available and we can display on the UI
        ResultTextView.Text = "Length: " + intResult ;
        // "returns" void, since it's an event handler
    };
    public async Task<int> DownloadHomepage()
    {
        var httpClient = new HttpClient(); // Xamarin supports HttpClient!
    
        Task<string> contentsTask = httpClient.GetStringAsync("http://xamarin.com"); // async method!
    
        // await! control returns to the caller and the task continues to run on another thread
        // "See await"
        string contents = await contentsTask;
    
        ResultEditText.Text += "DownloadHomepage method continues after async call. . . . .\n";
    
        // After contentTask completes, you can calculate the length of the string.
        int exampleInt = contents.Length;
    
        ResultEditText.Text += "Downloaded the html and found out the length.\n\n\n";
    
        ResultEditText.Text += contents; // just dump the entire HTML
    
        return exampleInt; // Task<TResult> returns an object of type TResult, in this case int
    }
