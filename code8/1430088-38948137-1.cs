    protected void OnBtnClicked(object sender, EventArgs e)
    {
        try
        {
    		var mdCalculate = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.None, "Processing...");
    		mdCalculate.Title = "Calculate";
    		mdCalculate.Show();
    		
            Task.Factory.StartNew(() =>
            {
                //Some sync calls to remote services
                //...
    			
    			//returns the data I will show in the UI, lets say it's a string
    			return someData;
            }).ContinueWith((prevTask) =>
    		{
    			Application.Invoke((send, evnt) =>
    			{
    				txtResult.Buffer.Text = prevTask.Result; //this is the string I returned before (someData)
    				mdCalculate.Hide();
    				mdCalculate.Destroy();
    			});
    		});
        }
        catch (Exception ex)
        {
            var dlg = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Close, ex.Message);
            dlg.Title = "Error";
            dlg.Run();
            dlg.Destroy();
        }
    }
