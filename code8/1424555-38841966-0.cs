    protected void insertdata(object sender, EventArgs e)
    {
         foreach (GridViewRow row in grdPIData.Rows)
         {
              string sCon = ConfigurationManager.ConnectionStrings["conName"].ConnectionString);
              SqlConnection con = new SqlConnection(sCon);
              SqlCommand cmd = new SqlCommand("Insert into Table1(oDate, oTag, oVal) Values ('" & row.Cells[0].Text.ToString() + "' + row.Cells[1].Text.ToString() + "' + '" + row.Cells[2].Text.ToString() + "')", con);
              con.Open();
              cmd.ExecuteNonQuery();
              con.Close();
         }
    }
