    void DropDownlist1_SelectedIndexChanged(Object sender, EventArgs e)
    {
       if(DropDownlist1.SelectedIndex != -1)
       {
           using(var con = new SqlConnection(conString))
           using(var cmd = con.CreateCommand())
           {
                 cmd.CommandText = "SELECT Nickname FROM tbl_AAA WHERE ID = @id";
                 cmd.Paramerters.Add("@id", SqlDbType.Int)
                                .Value = int.Parse(DropDownlist1.SelectedValue);
                 con.Open();
                 Label1.Text = (string)cmd.ExecuteScalar();
           }
       }
       else
       {
           Label1.Text = string.Empty;
       }
    }
