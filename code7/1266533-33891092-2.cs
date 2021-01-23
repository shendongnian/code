    private void simpleButton1_Click(object sender, EventArgs e)
    {
        DevExpress.XtraRichEdit.API.Native.DocumentPosition position = richEditControl1.Document.CaretPosition;
        if (richEditControl1.Document.Text.Length > 0)
        {
            //Returns all previous text befor the caret
            XtraMessageBox.Show(richEditControl1.Document.Text.Substring(0, position.ToInt()));
            int intPosition = position.ToInt();
            if (intPosition > 0 && intPosition < richEditControl1.Document.Length)
            {
                //It will return previous character
                XtraMessageBox.Show(richEditControl1.Document.Text.Substring(intPosition - 1, 1));
            }
        }
    }
