    int orderprice = 0;
    int proprice = 0;
    int quantity = 0;
    if (int.TryParse(txt_oprice.Text, out proprice) && int.TryParse(cb_oqty.SelectedValue.ToString(), out quantity))
	{
	    // It was assigned.
        orderprice = proprice * quantity;
	}
    else
    {
        //Error
    }
