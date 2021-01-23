    bool canDoHardWork = true;
    
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
       if (canDoHardWork)
       {
    	IAsyncResult result;
        Task.Factory.StartNew(() =>
        {
           canDoHardWork = false;
           result = this.BeginInvoke((Func<Button>)(() =>
           {                         
               canDoHardWork = true;
               return PopulateTabs(); // Very hard work
           }), null);
    	   this.dataGridView1.Controls.Add((Button)this.EndInvoke(result));
           dataGridView1.Focus();
        });
       }
    }
