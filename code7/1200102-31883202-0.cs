    object linktext = txtDisplayText.Text;
    object result = "MY URL";
    object missObj = Type.Missing;
    
    Outlook.MailItem currentMessage = 
         Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;
    Word.Document doc = currentMessage.GetInspector.WordEditor;
    Word.Selection objSel = doc.Windows[1].Selection;
    doc.Hyperlinks.Add
         (objSel.Range, ref result, ref missObj, ref missObj, ref linktext, ref missObj);
