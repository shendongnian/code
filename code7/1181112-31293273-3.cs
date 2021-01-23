    protected void btn_send_Click(object sender, EventArgs e)
    {
   
         SqlDataSource1.Insert();
  
    }
    protected void On_Inserted(Object sender, SqlDataSourceStatusEventArgs e) 
    {
        string sID = e.Command.Parameters["@Id"].Value.ToString();
          Response.Redirect("documentsnew.aspx?id=" + sID);
    }
