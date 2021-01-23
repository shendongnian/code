    private void textEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
    {
        e.Cancel = !e.NewValue.ToString().Contains("-");
    }
 
