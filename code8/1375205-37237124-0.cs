    textEdit1.Properties.Mask.EditMask = "-[0-9]*[.]{0,1}[0-9]*";
    textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
    
    private void textEdit1_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e) {
        if (e.Value is string) {
            e.Value = double.Parse(e.Value.ToString());
            e.Handled = true;
        }
    }
