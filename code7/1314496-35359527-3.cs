    protected void btn_Click(object sender, EventArgs e)
    {
        var lst = new List<string>();
        foreach (RepeaterItem item in rpt.Items)
        {
            if (item.ItemType == ListItemType.Item ||
                item.ItemType == ListItemType.AlternatingItem)
            {
                var multiView = (MultiView)item.FindControl("multiView");
                if (multiView.ActiveViewIndex == 0)
                {
                    var radioBtn = (RadioButton)item.FindControl("radioBtn");
                    lst.Add("Radio button is " + (radioBtn.Checked ? "" : "not ") + "checked.");
                }
                else
                {
                    var checkBox = (CheckBox)item.FindControl("checkBox");
                    lst.Add("Check box is " + (checkBox.Checked ? "" : "not ") + "checked.");
                }
            }
        }
    }
