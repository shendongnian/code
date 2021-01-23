     private void timer_updateGui_Tick(object sender, EventArgs e)
    {
        lock(MyClass.dt)
        {
        chart_highLevel.DataSource = MyClass.dt.Clone();
        }
        chart_highLevel.DataBind(); // Update the databind
        
    }
        public DataTable dt = {get; private set;}
    private void bw_analyser_DoWork(object sender, DoWorkEventArgs e)
    {
        while(true)
        {    
            // ... populate 'values'
            lock(dt)
            {
            dt.Rows.Add(values); // values are the data to fill the DataTable, dt          }
        }
    }
