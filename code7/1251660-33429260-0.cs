    Use GridView2.Rows instead of GridView.
     foreach (GridViewRow row in GridView2.Rows)
         {
             A=(HyperLink)row.FindControl("hyp");
             A.NavigateUrl += A.Text;
         }
