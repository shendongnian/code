    void UpdateCounter()
    {
        if (InvokeRequired)
        {
            BeginInvoke(new MethodInvoker(UpdateCounter));
            return;
        }
        CounterValue.Text = Counter.ToString();
    }
