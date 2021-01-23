    protected void gvTest_DataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
         Label lblCountry = (Label)e.Row.FindControl("Label1");
         if (lblCountry.text == "usa"){
          // do something here
         }
         else {
          // do something otherwise
         }
      }
    }
