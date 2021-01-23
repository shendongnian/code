    private void simpleButton1_Click(object sender, EventArgs e)
    {
        DevExpress.XtraRichEdit.API.Native.DocumentPosition position = richEditControl1.Document.CaretPosition;
        if (richEditControl1.Document.Text.Length> 0)
        {
            XtraMessageBox.Show(richEditControl1.Document.Text.Substring(0, position.ToInt()));    
        }            
