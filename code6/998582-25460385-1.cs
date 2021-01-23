	try
	{
		textBox1.Text = "Started";
		this.IsHitTestVisible = false; // this being the window
		await Task.Factory.StartNew(() => {
			this.GetTheJobDone();
		});
		textBox1.Text = "Done";
	}
	catch (Exception ex)
	{
		this.textBox1.Text = "Error: " + ex.Message;
	}
	finally
	{
		this.IsHitTestVisible = true;
	}
