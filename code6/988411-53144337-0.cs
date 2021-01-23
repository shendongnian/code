     protected void Button3_Click(object sender, EventArgs e)
    {
        viewrecord s = new viewrecord();
        s.std_id = Convert.ToInt32(TextBox2.Text);
        SqlConnection conn2 = new SqlConnection(connstring);
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("viewrecord", conn2);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@std_id", s.std_id);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataSourceID = "";
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorMsgBoxBack.aspx");
        }
        finally
        {
            conn2.Close();
        }
}
