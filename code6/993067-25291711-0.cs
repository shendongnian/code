    foreach (DataListItem dli in dlGiftCode.Items)
    {
        if (dli != clickedItem)
        {
            TextBox tb = (TextBox)dli.FindControl("txtCardCode");
            if (tb.Text == clickedTextbox.Text)
            {
                giftCount++;            
            }
        }
    }
