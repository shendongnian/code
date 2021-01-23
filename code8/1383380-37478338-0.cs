        string checkedValue = "";
        string uncheckedValue = "";
        foreach (ListItem val in chkbxFileTypes.Items)
        {
            if (val.Selected)
            {
                checkedValue += val.Value + " ";
            }
            else
            {
                uncheckedValue += val.Value + ",";
            }
        }
    }
