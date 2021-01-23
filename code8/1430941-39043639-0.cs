    object link = url;
    object res = "url";
    object missing = Type.Missing;
    
    // get active inspector (note that this assumes you work always on the active email message).
    var inspector = ThisAddIn.Application.ActiveInspector();
    MailItem email = inspector.CurrentItem;  // get the email message 
    Microsoft.Office.Interop.Word.Document document = email.GetInspector.WordEditor;
    Microsoft.Office.Interop.Word.Selection sel = document.Windows[1].Selection;
    doc.Hyperlinks.Add(sel.Range, ref res, ref missing, ref missing, ref link, ref missing);
    sel.EndKey(Microsoft.Office.Interop.Word.WdUnits.wdLine);  // move to the end of selection
    sel.InsertAfter("\n");  // insert new line
    sel.MoveDown(Microsoft.Office.Interop.Word.WdUnits.wdLine);  // move one line down
