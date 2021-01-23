    
    private async void ds_StartButton_Click(object sender, EventArgs e)
    {
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Started MSDN Example ..." + Environment.NewLine);
    
        // Call the method that runs asynchronously.
        string result = await WaitAsynchronouslyAsync();
    
        // Call the method that runs synchronously.
        //string result = await WaitSynchronously ();
    
        // Do other Schdaff
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Foobar #1 ..." + Environment.NewLine);
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Foobar #2 ..." + Environment.NewLine);
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Foobar #3 ..." + Environment.NewLine);
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Foobar #4 ..." + Environment.NewLine);
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Foobar #5 ..." + Environment.NewLine);
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Foobar #6 ..." + Environment.NewLine);
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Foobar #7 ..." + Environment.NewLine);
    
        // Display the result.
        textBox1.Text += result;
    }
    
    // The following method runs asynchronously. The UI thread is not
    // blocked during the delay. You can move or resize the Form1 window 
    // while Task.Delay is running.
    public async Task<string> WaitAsynchronouslyAsync()
    {
        Console.WriteLine(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Entered WaitAsynchronouslyAsync()");
        await Task.Delay(10000);
        Console.WriteLine(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Task.Delay done, starting random string generation now ...");
    
        await Task.Run(() => LongComputation());
    
        Console.WriteLine(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Leaving WaitAsynchronouslyAsync() ...");
        return DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Finished MSDN Example." + Environment.NewLine;
    }
    
    // The following method runs synchronously, despite the use of async.
    // You cannot move or resize the Form1 window while Thread.Sleep
    // is running because the UI thread is blocked.
    public async Task<string> WaitSynchronously()
    {
        // Add a using directive for System.Threading.
        Thread.Sleep(10000);
        return DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Finished MSDN Bad Ass Example." + Environment.NewLine;
    }
    
    private void ds_ButtonTest_Click(object sender, EventArgs e)
    {
        textBox1.AppendText(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Started Test ..." + Environment.NewLine);
        Task<string> l_Task = WaitAsynchronouslyAsync();
        //WaitAsynchronouslyAsync();
    
        //textBox1.AppendText(l_Result);
    }
    
    private void LongComputation()
    {
        Console.WriteLine(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Generating random string ...");
    
        string l_RandomString = GetRandomString(10000000);
    
        Console.WriteLine(DateTime.Now.ToString() + " [" + Thread.CurrentThread.ManagedThreadId + "] Random string generated.");
    }
    
    /// <summary>Get random string with specified length</summary>
    /// <param name="p_Length">Requested length of random string</param>
    /// <param name="p_NoDots">Use case of this is unknown, but assumed to be importantly needed somewhere. Defaults to true therefore.
    /// But due to huge performance implication, added this parameter to switch this off.</param>
    /// <returns>Random string</returns>
    public static string GetRandomString(int p_Length, bool p_NoDots = true)
    {
        StringBuilder l_StringBuilder = new StringBuilder();
        string l_RandomString = string.Empty;
    
        while (l_StringBuilder.Length <= p_Length)
        {
            l_RandomString = (p_NoDots ? System.IO.Path.GetRandomFileName().Replace(".", string.Empty) : System.IO.Path.GetRandomFileName());
            l_StringBuilder.Append(l_RandomString);
        }
    
        l_RandomString = l_StringBuilder.ToString(0, p_Length);
        l_StringBuilder = null;
    
        return l_RandomString;
    }
