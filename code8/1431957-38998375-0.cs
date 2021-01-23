    private BackgroundWorker worker;
    private DataTable table;
    
    private void button2_Click(object sender, EventArgs e)
    {
      if (worker != null)
      {
        worker.CancelAsync();
      }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {  
      this.worker = new BackgroundWorker();
      worker.WorkerReportsProgress = true;
      worker.WorkerSupportsCancellation = true;
    
      worker.DoWork += new DoWorkEventHandler(worker_DoWork);
      worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
    
      worker.RunWorkerAsync();
    }
    
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      MessageBox.Show(this.table.Rows.Count.ToString());
    }
    
    [System.Diagnostics.DebuggerStepThrough]
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      this.table = new DataTable();
    
      using (SqlConnection connection= new SqlConnection())
      using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM table", connection))
      {
        table.RowChanged += new DataRowChangeEventHandler(table_RowChanged); 
        da.Fill(table);        
      }
    }
    
    [System.Diagnostics.DebuggerStepThrough]
    void table_RowChanged(object sender, DataRowChangeEventArgs e)
    {
      if (worker.CancellationPending)
      {
        throw new ApplicationException("Canceled"); // throw a spanner in the works
      }
      Thread.Sleep(5); // Just slow things down for testing
    }
