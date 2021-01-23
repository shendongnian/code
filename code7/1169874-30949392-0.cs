    private void button1_Click(object sender, EventArgs e)
    {
        ThreadPool.QueueUserWorkItem(p => doit());            
    }
    private void doit()
    {
        int xa;
        int ya;
        for (xa = 647; xa < 982; xa++)
            for (ya = 262; ya < 598; ya++)
            {
                this.Invoke(new Action(() => { label1.Text = xa.ToString() + " " + ya.ToString(); }));
            }
    }
