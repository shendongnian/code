    private void ChangeFilesTimer_Tick(object sender, EventArgs e)
    {
        try
        {
            RunChangeFiles();
        }
        catch (Exception ex)
        {
            ThreadPool.QueueUserWorkItem(
                _ => { throw new Exception("Exception on timer thread.", exception); });
        }
    }
