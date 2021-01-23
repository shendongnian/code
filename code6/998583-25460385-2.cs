	textBox1.Text = "Started";
	this.IsHitTestVisible = false; // this being the window
	try
	{
		Task.Factory.StartNew(() => {
			// handle errors so that IsHitTestVisible will be enabled after error is handled
			try
			{
				this.GetTheJobDone();
				Dispatcher.Invoke(() => {
					// invoke required as we are on a different thead
					textBox1.Text = "Done";
				});
			}
			catch (Exception ex)
			{
				Dispatcher.Invoke(() => {
					this.textBox1.Text = "Error: " + ex.Message;
				});
			}
			finally
			{
				Dispatcher.Invoke(() => {
					this.IsHitTestVisible = true;
				});
			}
		});
	}
	catch (Exception ex)
	{
		this.textBox1.Text = "Error: " + ex.Message;
		this.IsHitTestVisible = true;
	}
