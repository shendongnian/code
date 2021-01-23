    cmd.Connection = con;
    con.Open();
    string s = "select count(*) from quoation111";
    cmd.CommandText = s;
    
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    sda.Fill(ds); //Filling Data into Data Adapter  
    
    int rowcount = ds.Tables[0].Rows.Count ;
    for (int i = TextBox1.Text;i<= rowcount;i++)
    {
       TextBox1.Text = i.ToString();
    }
                        
