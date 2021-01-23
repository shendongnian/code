        ...
        HtmlGenericControl dtbackup = ((HtmlGenericControl)e.Item.FindControl("bkdate"));
    DateTime date2 = DateTime.Today;
                DateTime idate = (DateTime)(DataBinder.Eval(e.Item.DataItem, "myDate"));
    if (idate < date2)
                {
                    dtbackup.Attributes.Add("class", "bad");
                }
                else
                {
                    dtbackup.Attributes.Add("class", "good");
                }
