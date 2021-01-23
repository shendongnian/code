    using Word = Microsoft.Office.Interop.Word;
    Word._Application application;
    Word._Document document;
    Object missingObj = System.Reflection.Missing.Value;
    Object trueObj = true;
    Object falseObj = false;
    
    private void create_button1_Click(object sender, EventArgs e) {
       //ReplaceTextInWord("template.dot", "find me", "Found"); <-- Are you sure you want to replace in a Template?
       ReplaceTextInWord(@"C:\Temp\template.docx", "%%mark%%","text to replace");  //I think you want a .DOC or DOCX file
    }
    
    private void ReplaceTextInWord(string wordDocFilePath, string strToFind, string replaceStr) {
    	application = new Word.Application();
    	try {
    		//document = application.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj); 
            document = application.Documents.Open(wordDocFilePath);  //You need to open Word Documents, not add them, as per https://msdn.microsoft.com/en-us/library/tcyt0y1f.aspx
    	}
    	catch (Exception error) {
    		document.Close(ref falseObj, ref missingObj, ref missingObj);
    		application.Quit(ref missingObj, ref missingObj, ref missingObj);
    		document = null;
    		application = null;
    		throw error;
    	}
    
    	for (int i = 1; i <= document.Sections.Count; i++) {
    	Word.Range wordRange = document.Sections[i].Range;
    	Word.Find findObject = wordRange.Find;
    	findObject.ClearFormatting();
    	findObject.Text = strToFind;
    	findObject.Replacement.ClearFormatting();
    	findObject.Replacement.Text = replaceStr;
    
    	object replaceAll = Word.WdReplace.wdReplaceAll;
    	findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
    		ref missing, ref missing, ref missing, ref missing, ref missing,
    		ref replaceAll, ref missing, ref missing, ref missing, ref missing);
    	}
    	application.Visible = true;
    }
