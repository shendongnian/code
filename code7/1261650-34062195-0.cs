    var doc = Globals.DLPAddIn.Application.ActiveDocument;
    var xml = doc.WordOpenXML;
    
    var newDoc = Globals.DLPAddIn.Application.Documents.Add();
    newDoc.Range.Text = xml
