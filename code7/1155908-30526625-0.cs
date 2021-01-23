    protected void Button1_Click(object sender, EventArgs e)
    {
    	var task = RunSample();
    	task.Wait();
    }
    
    private static async Task RunSample()
    {
    	await SomeMethodAsync("some value");
    }
