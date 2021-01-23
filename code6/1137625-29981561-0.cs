       protected void DataList2_ItemDataBound1(object sender, DataListItemEventArgs e)
        {
            if (userIdData.Equals(Int32.Parse(Session["userId"].ToString())))
            {
                Button cmdButton = e.Item.FindControl("commentEditButton") as Button;
                if (cmdButton != null) cmdButton.Visible = true;
            }
        }
