    protected void Submit1_Click(object sender, EventArgs e)
    {
        SqlConnection a = new SqlConnection(@"Connection String");
    SqlCommand o = new SqlCommand("Select * from Log where Username='" + TextBox3.Text + "'And Password='" + TextBox5.Text + "'", a);
    a.Open();
    SqlDataReader r = o.ExecuteReader();
    if (r.Read())
    {
        Label1.Visible = true;
    }
    else
    {
        Label1.Visible = true;
        Label1.Text = "RETRY";
    }
        a.Close();
}
