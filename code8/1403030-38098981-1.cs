        Label lblCost;
        Quote.QuoteDetails qd = (Quote.QuoteDetails)e.Item.DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            lblCost = (Label)e.Item.FindControl("lblCost");
            if (qd.Approved1)
                lblCost.Text = string.Format("{0:0.00", qd.Cost);
            else if (qd.Approved2)
                lblCost.Text = string.Format("{0:0.00", qd.Cost2);
            else
                throw new NotImplementedException("oops!");
        }
    }
