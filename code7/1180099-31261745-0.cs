    bool working;
    public void Begin(int input)
    {   
        if (!working)
        {
            working = true;
            Action<int> Start = new Action<int>(StartCount);
            IAsyncResult result = Start.BeginInvoke(input, (res) => working = false, null);
        }
    }
