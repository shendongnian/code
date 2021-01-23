    protected void ButtonClick(object sender, EventArgs e)
    {
        foreach (ListViewItem lvi in SectionListView.Items)
        {
            if (lvi.ItemType == ListViewItemType.DataItem)
            {
                HtmlTableCell row1 = (HtmlTableCell)lvi.FindControl("row1");
                row1.Style.Add("visibility", "hidden");
            }
        }
    }
