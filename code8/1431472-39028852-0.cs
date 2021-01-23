        public void AddLinkToCurrentInspector(string url)
        {
            object link = url;
            object result = "url";
            object missing = Type.Missing;
            var inspector = MyAddIn.Application.ActiveInspector();
            MailItem currMessage = inspector.CurrentItem;
            Microsoft.Office.Interop.Word.Document doc = currMessage.GetInspector.WordEditor;
            Microsoft.Office.Interop.Word.Selection sel = doc.Windows[1].Selection;
            doc.Hyperlinks.Add(sel.Range, ref result, ref missing, ref missing, ref link, ref missing);
            sel.EndKey(Microsoft.Office.Interop.Word.WdUnits.wdLine);
            sel.InsertAfter("\n");
            sel.MoveDown(Microsoft.Office.Interop.Word.WdUnits.wdLine);
        }
