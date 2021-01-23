    private void button_Print_Click(object sender, EventArgs e)
    {
         Thread t = new Thread(new ThreadStart(ThreadProc));
        t.Start();
        // Printing processing...
        // Printing processing...
        // Printing processing...
        // Printing processing...
        // Printing finished.
    
        if(t.IsAlive)
        t.Abort();
    }
    void ThreadProc()
    {
    MessageBox.Show("Printing... Please Wait...","Printing...");
    }
