    var i = 0;
    while (i < DropDownList1.Items.Count)
    {
        if (string.IsNullOrEmpty(DropDownList1.Items[i].Value))
        {
            DropDownList1.Items.RemoveAt(i);
        } else
        {
            i ++;
        }
    }
