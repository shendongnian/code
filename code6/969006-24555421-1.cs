    public void rt_changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
      // Declare l, also give it a default value, in the case that datalist is empty.
      Label l = null;
      foreach (DataListItem li in datalist.Items)
      { 
        l = li.FindControl("nl") as Label;
      }
      Label3.Text = l.ToString(); // l values is not getting
    }
