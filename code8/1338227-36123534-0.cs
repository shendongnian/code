        DataGridViewComboBoxColumn dcom = new DataGridViewComboBoxColumn();
        dcom.HeaderText = "Combobox";
        dcom.Name = "cmb";
        dcom.MaxDropDownItems = 2;
        dcom.Items.Add("Sale");
        dcom.Items.Add("Return");
        custCartGrid.Columns.Add(dcom);
