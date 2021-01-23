    protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
             if (e.CloseReason == CloseReason.UserClosing) 
             {
                //Some Code
             }
        }
