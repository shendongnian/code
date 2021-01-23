    protected void Button1_Click(object sender, EventArgs e)
    {
    GridView1.Visible = true;
    DataTable dt = new DataTable();
    DataRow row = dt.NewRow();
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
 
    TextBox txtUsrId=(TextBox)GridView1.Rows[i].FindControl("Your textbox id");
    string UserID = txtUsrId.Text;
    string q="insert into details (name) values('"+UserID+"')";
    SqlCommand cmd = new SqlCommand(q, con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
}
}
