	private async void button1_Click(object sender, EventArgs e)
    {
        ...
		await ProcessFile(openFileDialog1.FileNames.First());
        ...
    }
	
	private async Task ProcessFile(string path) 
	{
		return Task.StartNew(() => { 
			IEnumerable<T> products = GetProducts<T>(path);
			foreach (var item in products)
			{
				string select = @"select something from datatable";
				List<object[]> result = await  Support.Overall.RetrieveSelectDataAsync(select);
			
				// i'm using a little helper method here...
				Do(richTextBox1, rb => rb.AppendText(int.Parse...);
			}
		});
	}
	
	public static void Do<TControl>(TControl control, Action<TControl> action) where TControl : Control
	{
		if (control.InvokeRequired)
		{
			control.Invoke(action, control);
		}
		else
		{
			action(control);
		}
	}
