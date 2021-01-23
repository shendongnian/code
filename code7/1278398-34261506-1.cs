    private Form2 _frmForm2; //Field for holding the current Form2 instance.
    
    public void ShowForm2()
    {
        _frmForm2 = new Form2();
        _frmForm2.Show();
    }
    
    private void grvAsmenys_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {        
        //Form2 frmForm2 = new Form2();
        //Use the field instead.
        _frmForm2.taKlaus.FillByID(_frmForm2.dsKlaus.Klaus,
            Convert.ToInt32(Id()));
    }
