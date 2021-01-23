    private void button6_Click(object sender, EventArgs e)
    {
    Sqlconnection con=new SqlConnection(strcon);
    con.Open();
    SqlCommand cmd=new SqlCommand("SELECT SUM(column_name) FROM   table_name",con);
    SqlDataReader dr=cmd.ExecuteReader();
    while(dr.Read())
    {
    textBox6.Text = dr[0].toString();
    }
}
