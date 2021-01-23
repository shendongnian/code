    private Word.ApplicationClass oWord;
    	
    private void button1_Click(object sender, System.EventArgs e)
    {
    	//===== Create a new document in Word ==============
    	// Create an instance of Word and make it visible.
    	oWord = new Word.ApplicationClass();
    	oWord.Visible = true;
    
    	// Local declarations.
    	Word._Document oDoc;
    	Object oMissing = System.Reflection.Missing.Value;
    
    	// Add a new document.
    	oDoc = oWord.Documents.Add(ref oMissing,ref oMissing,
    		ref oMissing,ref oMissing); // Clean document
    
    	// Add text to the new document.
    	oDoc.Content.Text = "Handle Events for Microsoft Word Using C#.";
    	oDoc = null;        
    
    	//============ Set up the event handlers ===============
    
    	oWord.DocumentBeforeClose += 
    		new Word.ApplicationEvents3_DocumentBeforeCloseEventHandler( 
    		oWord_DocumentBeforeClose );  
    	oWord.DocumentBeforeSave += 
    		new Word.ApplicationEvents3_DocumentBeforeSaveEventHandler( 
    		oWord_DocumentBeforeSave );  
    	oWord.DocumentChange += 
    		new Word.ApplicationEvents3_DocumentChangeEventHandler( 
    		oWord_DocumentChange );
    	oWord.WindowBeforeDoubleClick += 
    		new Word.ApplicationEvents3_WindowBeforeDoubleClickEventHandler( 
    		oWord_WindowBeforeDoubleClick );
    	oWord.WindowBeforeRightClick +=
    		new Word.ApplicationEvents3_WindowBeforeRightClickEventHandler( 
    		oWord_WindowBeforeRightClick );
    }
    
    // The event handlers.
    
    private void oWord_DocumentBeforeClose(Word.Document doc, ref bool Cancel)
    {
    	Debug.WriteLine(
    		"DocumentBeforeClose ( You are closing " + doc.Name + " )");
    }
    
    private void oWord_DocumentBeforeSave(Word.Document doc, ref bool SaveAsUI, ref bool Cancel)
    {
    	Debug.WriteLine(
    		"DocumentBeforeSave ( You are saving " + doc.Name + " )");
    }
    
    private void oWord_DocumentChange()
    {
    	Debug.WriteLine("DocumentChange");
    }
    
    private void oWord_WindowBeforeDoubleClick(Word.Selection sel, ref bool Cancel)
    {
    	Debug.WriteLine(
    		"WindowBeforeDoubleClick (Selection is: " + sel.Text + " )");
    }
    
    private void oWord_WindowBeforeRightClick(Word.Selection sel, ref bool Cancel)
    {
    	Debug.WriteLine(
    		"WindowBeforeRightClick (Selection is: " + sel.Text + " )");
    
    }
