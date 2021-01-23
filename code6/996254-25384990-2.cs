    private void Form1_Load(object sender, System.EventArgs e)
    {
        Task t = new Task(() =>
        {
            //Logic
    
            //...
    
            //Update UI
            this.Invoke((MethodInvoker)delegate
            {
                listbox.Items.Add(...); // runs on UI thread
            });
        });
        t.Start();
    }
