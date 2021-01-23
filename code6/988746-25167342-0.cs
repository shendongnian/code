    public static void SaveAsXMLAndDoSomethingElse() {
    	String fn = @"C:\Users\zbook\Desktop\Track test.docx";
    	String fn_xml = @"C:\Users\zbook\Desktop\Track test3.xml";
    	Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    	Documents docs = app.Documents;
    	Document doc = docs.Open(fn, ReadOnly:true);
    	//bool b = doc.TrackFormatting; // for some reason this line bombs
    	doc.SaveAs2(fn_xml, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXML);
    	doc.Close(false);
    	Marshal.ReleaseComObject(doc);
    
    	// now open up fn_xml ... and do whatever
    
    	app.Quit(false);
    	Marshal.ReleaseComObject(docs);
    	Marshal.ReleaseComObject(app);
    }
