        string items = string.Empty;
        foreach (CheckedListBoxItem item in checkedComboBoxEdit1.Properties.GetItems())
            if (item.CheckState == CheckState.Checked)
                items += string.Format("{0} YES \r\n", item.Description);
            else
                items += string.Format("{0} NO \r\n", item.Description);
        items = items.TrimEnd("\r\n".ToCharArray());
        XtraMessageBox.Show(items);
