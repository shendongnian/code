    dtpCloseDate.Checked = false;
    dtpCloseDate.ShowCheckBox = false;
    
    if (dtpCloseDate.Checked == false)
    {
        dtpCloseDate.CustomFormat = " ";
        dtpCloseDate.Format = DateTimePickerFormat.Custom;
        dtpCloseDate.Value = DateTime.MinValue;
    }
