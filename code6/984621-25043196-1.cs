    string ret = "";
    foreach(var item in checkbox.items)
    {
        if(item.Selected)
        {
            if (ret.Length > 0)
            {
                ret += ", ";
            }
            ret += item.Text;
        }
    }
