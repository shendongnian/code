        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var dataItem = e.Item.DataItem as SomeType // [The type of object you use for the ListView binding];
                var subpro = e.Item.FindControl("List2QuoteSubProject") as DropDownList;
                BindDropDownList(subpro, "SELECT SubProjectID, SubProjectCode FROM SubProject A INNER JOIN Project B ON A.ProjectID = B.ProjectID ORDER BY B.ProjectCode, A.SubProjectCode", "SubProject", "SubProjectCode", "SubProjectID");
                subpro.SelectedValue = dataItem.SubProjectID;
            }
        }
