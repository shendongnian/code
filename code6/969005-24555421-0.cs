    public void rt_changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
      Label l;
      foreach (DataListItem li in datalist.Items)
      { 
        l = li.FindControl("nl") as Label;
      }
      Label3.Text = l.ToString(); // l values is not getting
    }
