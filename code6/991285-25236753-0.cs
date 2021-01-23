    public void ThreadFunc(object param)
    {
        string SessionParameter = (string)param;
        while (true)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                label1.Text = DateTime.Now.ToString() + @"_" + SessionParameter;
            });
            Thread.Sleep(250);
        }
    }
