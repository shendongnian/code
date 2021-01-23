    try {
      cmd.ExecuteNonQuery();
      GridView1.DataBind();
      Label1.Visible = true;
      Label1.Text = "Stock Successfully Removed!";
    } catch (SqlException e) {
      Label1.Visible = true;
      Label1.Text = e.ToString();
    }
