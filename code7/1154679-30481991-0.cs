    private void F()
    {
        for (int i = 0; i < 10; i++)
        {
           label1.Invoke(new MethodInvoker(HardWork));
           Thread.Sleep(300);//Sleep in worker thread, not in UI thread
        }
    }
    private void HardWork()
    {
        label1.Text += "x";
        //No sleep here. This runs in UI thread!
    }
