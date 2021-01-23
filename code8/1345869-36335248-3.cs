    if (winemaker_comboBox.SelectedItem != DBnull.Value)
    {
        var names = winemaker_comboBox.SelectedValue.ToString().Split(',');
        string lastname = names[0];
        string firstname = names[1];
        string middlename = names.Length > 2 ? names[2] : string.Empty;
    }
