    public void AddPathsToNewEmailMessage(string path)
    {
    	object link = url;
    	object result = "url";
    	object missing = Type.Missing;
        string nl = "\n";
    
    	var inspector = ThisAddIn.Application.ActiveInspector();
    	MailItem currMessage = inspector.CurrentItem;
    	Word.Document doc = currMessage.GetInspector.WordEditor;
    	Word.Selection sel = doc.Windows[1].Selection;
    	doc.Hyperlinks.Add(sel.Range, ref result, ref missing, ref missing, ref link, ref missing);
    	sel.EndKey(Word.WdUnits.wdLine);
    	sel.InsertAfter(nl);
    	sel.MoveDownWord.WdUnits.wdLine);
    }
