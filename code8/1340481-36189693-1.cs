        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RegisterAsyncTask(new PageAsyncTask(LoadUrlContent));
            }
            catch {}
        }
    
        protected async Task LoadUrlContent()
        {
            try
            {
            // Add your code here, for example read the content using HttpClient:
            string _content = await ReadTextAsync(YourUrl, 10);
            }
            catch { throw; }
        }
