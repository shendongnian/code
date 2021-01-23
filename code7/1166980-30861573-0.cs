        public void Test()
        {
            Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
            Globals.ThisAddIn.Application.Selection.Text = string.Format("Hello{0}1{1}2{0}4{1}",((char)11).ToString(),((char)13).ToString());
            doc.SaveAs2("Test", Word.WdSaveFormat.wdFormatPDF);
        }
