    int totalRows = GridView1.Rows.Count;
    for (int RowIndex = 0; i < totalRows; RowIndex++)
        {
            GridViewRow row = GridView1.Rows[RowIndex];
            TextBox txtcode = row.FindControl("txtcode") as TextBox;
            TextBox txtalt = row.FindControl("txtalt") as TextBox;
            TextBox txtdetail = row.FindControl("txtdetails") as TextBox;
            SqlConnection myConnection = new SqlConnection("Data Source=SOMATCOSVR2015;
                                    Initial Catalog=SimsVisnu;User ID=sa;Password=aDmin123");
            SqlCommand cmd = new SqlCommand("UPDATE Qtattemp SET Code = @Code,
                                       details = @details WHERE Code = @Code", myConnection);
            cmd.Parameters.AddWithValue("@Code", txtcode.Text.Trim());
            cmd.Parameters.AddWithValue("@details", txtdetail.Text.Trim());
            myConnection.Open();
            cmd.ExecuteNonQuery();
         }
     Response.Redirect(Request.Url.AbsoluteUri);
