     public void rt_changed(object sender, AjaxControlToolkit.RatingEventArgs e)
     {
         Label l = null;
         foreach (DataListItem li in datalist.Items)
         { 
              l = li.FindControl("nl") as Label;
         }          
         Label3.Text = (l == null ? string.Empty : l.Text); 
     }
