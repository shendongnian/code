    public void DisplayResults(int rowNumber)
    {
       textBox1.Text = ds.Tables[0].Rows[i]["ID"].ToString();
       textBox2.Text = ds.Tables[0].Rows[i]["empname"].ToString();
       textBox3.Text = ds.Tables[0].Rows[i]["salary"].ToString();
       //and so on so forth.
    }
