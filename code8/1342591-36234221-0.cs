    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s1 = DropDownList1.SelectedValue.ToString();
        string perfectid = string.Empty;
        con.Open();
        
        SqlCommand cmd = new SqlCommand("select song_name from songs where id=(select [Id] from [Table] where movie_name=@moviename",con);
        cmd.Parameters.AddWithValue("@moviewname", s1);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dta = new DataTable();
        sda.Fill(dta);
        con.Close();
        DropDownList2.DataSource = dta;
        DropDownList2.DataTextField = dta.Columns[0].ColumnName;
        DropDownList2.DataValueField = dta.Columns[0].ColumnName;
        DropDownList2.DataBind();
    }
