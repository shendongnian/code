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
        // Add your code here
        }
        catch { throw; }
    }
