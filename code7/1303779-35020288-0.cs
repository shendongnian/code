    var type = typeof(GENERIC_FTP_SEND);
    foreach (Control cntrl in ControlList){
        Object value = null;
        
        
        if (cntrl is TextBox){
             value = (cntrl as TextBox).Text;
        } else if (cntrl is GroupBox){
             value = (cntrl as GroupBox).SelectedValue;
        } //etc ...
        
        PropertyInfo pInfo = type.GetProperty(cntrl.ID);
        if (pInfo != null && value != null){
            pInfo.SetValue(ftpPartner, value, null);
        }
    }
