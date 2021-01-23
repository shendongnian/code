    private void button6_Click(object sender, EventArgs e)
    {
    Sqlconnection con=new SqlConnection(strcon);
    con.Open();
    SqlCommand cmd=new SqlCommand("SELECT SUM(column_name)as TotalHours FROM   table_name",con);
    SqlDataReader dr=cmd.ExecuteReader();
    while(dr.Read())
    {
    Label1.Text = dr[0].toString();
    }
    }
