    private void Form1_Load(object sender, EventArgs e)
    {
        using (DataTable dt = new DataTable())
        {
            dt.Columns.Add("1", typeof(int));
            dt.Columns.Add("2", typeof(int));
            dt.Columns.Add("3", typeof(int));
            //... your code
        }
    }
