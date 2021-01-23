    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection("Data Source=PCN-TOSH;Initial Catalog=mydb;Integrated Security=True");
        cn.Open();
        SqlCommand cm = new SqlCommand("INSERT INTO TableDate_Time (DateTime) OUTPUT inserted.myID VALUES (@DateTime)");
        cm.Parameters.Add("@DateTime", SqlDbType.DateTime);
        cm.Parameters["@DateTime"].Value = DateTime.Now;  
        cm.Connection = cn;
        Guid newID = (Guid)cm.ExecuteScalar();
    }
