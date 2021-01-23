    public async void ButtonThatStartsEverything_Click(object sender, EventArgs e)
    {
    	await DoTheDownloadStuff();
    }
    
    public async Task DoTheDownloadStuff()
    {
    	var client = new WebClient();
    	
    	foreach(var item in ListBox1.Items)
    	{
    		var expanded = item.Split(';');
    		var num = expanded[0];
    		var result = await client.DownloadDataAsyncTask(new Uri("http://127.0.0.1/sv/" + num));
    		if (result.Contains("uva"))
    		{
    			listBox2.Items.Add(num);
    		}
    	}
    }
