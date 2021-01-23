        string checkedid = "";
        string uncheckedValue = "";
        foreach (ListItem val in chkbxFileTypes.Items)
        {
            if (val.Selected)
            {
                checkedid += val.Value + " ";
            }
            else
            {
                uncheckedValue += val.Value + ",";
            }
        }
    }
