    public void FindAndReplaceWordText(ref Microsoft.Office.Interop.Word.Document wordDoc, string textToReplace, string newText)
		{
			object missing = System.Type.Missing;
			foreach (Microsoft.Office.Interop.Word.Range tmpRange in wordDoc.StoryRanges)
			{
				//set the text to find and replace
				tmpRange.Find.Text = textToReplace;
				tmpRange.Find.Replacement.Text = newText;
				
				tmpRange.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
				//Declare an object to pass as a parameter that sets the Replace parameter to the "wdReplaceOne" enum.
				object replaceOne = Microsoft.Office.Interop.Word.WdReplace.wdReplaceOne;
				//Execute the Find and Replace
				tmpRange.Find.Execute(ref missing, ref missing, ref missing,
				                      ref missing, ref missing, ref missing, ref missing,
				                      ref missing, ref missing, ref missing, ref replaceOne,
				                      ref missing, ref missing, ref missing, ref missing);
			}
		
