    public void rt_changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {
            //Label l = sender as Label;
            foreach (DataListItem li in datalist.Items)
            { 
        
              Label3.Text = (li.FindControl("nl") as Label).Text;
        
            }
        
         }
