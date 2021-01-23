    public Form2 : Form
    {
        public delegate void DbCheckHandler(object sender, DbEventArgs e);
        public event DbCheckHandler DbCheckComplete;
    
        //check the db
        DbCheckComplete(this, new DbEventArgs { ShouldClose = true; });
    
    }
    
    public Form1 : Form
    {
        Form2 form2 = new Form2();
        form2.DbCheckComplete += new DbCheckHandler(CheckDbResult);
        form2.Show();
    
        private void CheckDbResult(object sender, DbEventArgs e)
        {
            if(e.ShouldClose)
            {
                this.Close();
            }
        }
    }
