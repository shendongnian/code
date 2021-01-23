    int i = 0;
    object j = 0;
    int k = 0;
    string ss = null;
    string sp_item = null;
    sp_item = TxtItem.Text.Trim();
    k = 0;
    for (i = 0; i < sp_item.len-2; i++)
    {
    ss =  sp_item.Substring(i, 2);
    if (ss == "XX")
    {
    k = 1;
    i = 15;
    }
    }
    return k;
    }
