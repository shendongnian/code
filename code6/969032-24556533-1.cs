    public void rt_changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        // Declare l, also give it a default value, in the case that datalist is empty.
        Label l = null;
        foreach (DataListItem li in datalist.Items)
        {
            l = li.FindControl("nl") as Label;
            sb.AppendLine(l.Text);
        }
        Label3.Text = sb.ToString(); // l values is not getting
    }
