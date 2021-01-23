    //decide what to do with the response we get back from the bridge
    client.UploadStringCompleted += (o, args) => Dispatcher.BeginInvoke(() =>
    {
        try
        {
            ResponseTextBox.Text = args.Result;
        }
        catch (Exception ex)
        {
            ResponseTextBox.Text = ex.Message;
        }
          
    });
