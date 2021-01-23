    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        var worker = new Thread(DoWork);
        worker.IsBackground = true;
        worker.Start();
    }
    
    private void OnWorkComplete(Exception error)
    {
        if (error != null)
            MessageBox.Show(error.Message);
        button1.Enabled = true;
    }
    
    private void DoWork()
    {
        Exception error = null;
        try { DoWorkCore(); }
        catch (Exception ex) { error = ex; }
        Invoke(new Action(OnWorkComplete), error);
    }
    
    private void DoWorkCore()
    {
        test thTest = new test();
        // NOTE: No try/catch for showing message boxes, this is running on a non UI thread
        string[] strings = File.ReadAllLines("C:\\users\\alex\\desktop\\test.txt");
    
        bool flag = true;
        int counter = 0;
        int dataCount = strings.Length;
        // The rest of the code...
        // Pass a delegate to the other threads.
        // Make sure using Invoke when you need to access/update UI elements
    }
