    private CancellationTokenSource tokenSource = new CancellationTokenSource();
    private void button19_Click(object sender, EventArgs e)
    {
        //Signala the token source to cancel;
        tokenSource.Cancel();
        
        //Make a new token source, autoshot will still be listening to the old source because we passed in the token as an argument.
        tokenSource = new CancellationTokenSource();
        activatepuckbuttons();
        btn_status = true;
        label25.Visible = false;
        pictureBox1.Visible = false;
    }
    //We don't make this async void because we don't use await.
    private void StartAutoShotButton_Click(object sender, EventArgs e)
    {
        //We do not await this because we are using it in a fire-and-forget fashion.
        autoshot(tokenSource.Token);
    }
    //It is a bad habit to do `async void` when not using a event. Just have it return a task but not wait on it.
    private async Task autoshot(CancellationToken token)
    {
        try
        {
            while (true)
            {
    
                myport.Write("A1");
                label24.Text = "A";
                await Task.Delay(700, token);
    
                myport.Write("A0");
                label24.Text = "";
                await Task.Delay(2300, token);
    
    
                // ---
    
    
                myport.Write("B1");
                label24.Text = "B";
                await Task.Delay(700, token);
    
                myport.Write("B0");
                label24.Text = "";
                await Task.Delay(2300, token);
            }
     
            //...
    
        }
        catch(OperationCanceledException ex)
        {
            if(ex.CancellationToken 1= token)
            {
                //Something other than our token caused a cancel, we should let the error bubble up.
                throw;
            }
        }
    }
