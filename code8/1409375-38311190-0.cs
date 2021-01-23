    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
       {
          Label oLabel = (Label)e.Row.FindControl("Label1");
          if(oLabel != null)
          {
               //oLabel.BackColor = System.Drawing.Color.Red;//See below for cambial
               oLabel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCC99");
               oLabel.Text = "MyText";
          }
       }
    }
