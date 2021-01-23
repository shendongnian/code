    void lstView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.InsertItem)
        {
            Button btn1 = e.Item.FindControl("btn1") as Button;
            Button btn2 = e.Item.FindControl("btn2") as Button;
            btn1.OnClientClick = string.Format("var btn2 = document.getElementById('{0}'); btn2.setAttribute('disabled', 'disabled'); return false;", btn2.ClientID);
        }
    }
