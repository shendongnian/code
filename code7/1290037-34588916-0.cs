    protected override void OnClick(object sender, EventArgs args)
    {
       Thread worker = new Thread(HandleOnClick);
       worker.Start();
    }
    private void HandleOnClick()
    {
        Invoke(setLoading); // this will execute on the UI thread
        // do http stuff this happens when you do it
        Invoke(setUnloading); // This will execute on the UI thread as well
    }
