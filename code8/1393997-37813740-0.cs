    private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        cita = new citacao(this);
        // subscribe to the closing event
        cita.FormClosing += form_FormClosing;
        cita.Show();
    }
    // when Form 2 will be closed you can execute your important line in the event
    void form_FormClosing(object sender, FormClosingEventArgs e)
    {
        // BUT! you have to use the variable name!!!
        richEditControl1.Document.AppendText(cita.valor_edit[0]);    
    }
