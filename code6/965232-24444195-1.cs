    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if(GridView1.Rows.Count>0)
       {
        //GridView1.Rows[0].Visible = false;
          Button btnID=   (Button ) GridView1.Rows[0].FindControl("btnID");
           if(btnID !=null)
           {
            btnID.Visible=false
           }
       }
    }
