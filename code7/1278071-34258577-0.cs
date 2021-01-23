        public static void AddBookmarkAnywhere(Microsoft.Office.Interop.Word.Application app, string findText, string bookmarkName)
        {
            var doc = app.ActiveDocument;
            bool bFound;
            int occurenceNumber = 1; 
            foreach (Microsoft.Office.Interop.Word.Range rngStory in doc.StoryRanges)
            {
                var internalRangeStory = rngStory;
                do
                {
                	bFound = AddBookmarkInStory(internalRangeStory, findText, bookmarkName + occurenceNumber.ToString());
                	if(bFound)
                	{
                		occurenceNumber++;
                	}
                	
                    try
                    {
                        switch (internalRangeStory.StoryType)
                        {
                            case Microsoft.Office.Interop.Word.WdStoryType.wdEvenPagesHeaderStory: // 6
                            case Microsoft.Office.Interop.Word.WdStoryType.wdPrimaryHeaderStory:   // 7
                            case Microsoft.Office.Interop.Word.WdStoryType.wdEvenPagesFooterStory: // 8
                            case Microsoft.Office.Interop.Word.WdStoryType.wdPrimaryFooterStory:   // 9
                            case Microsoft.Office.Interop.Word.WdStoryType.wdFirstPageHeaderStory: // 10
                            case Microsoft.Office.Interop.Word.WdStoryType.wdFirstPageFooterStory: // 11
         
                            if (internalRangeStory.ShapeRange.Count > 0)
                            {
                                foreach (Microsoft.Office.Interop.Word.Shape oShp in internalRangeStory.ShapeRange)
                                {
                                    if (oShp.TextFrame.HasText != 0)
                                    {
                                        AddBookmarkInStory(oShp.TextFrame.TextRange, findText, bookmarkName);
                                    }
                                }
                            }
                            break;
         
                            default:
                                break;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Some error in function AddBookmarkAnywhere");
                    }
         
                    internalRangeStory = internalRangeStory.NextStoryRange;
                }
                while (internalRangeStory != null); 
            }
        }
        
        private static bool AddBookmarkInStory(Microsoft.Office.Interop.Word.Range rngStory, string strSearch, string bookmarkName)
        {
            rngStory.Find.ClearFormatting();
            rngStory.Find.Replacement.ClearFormatting();
            rngStory.Find.Text = strSearch;
            rngStory.Find.Replacement.Text = string.Empty;
            object findText = strSearch;
            object replaceText = strSearch;
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 0;  // replace = 0 replaces None, replace = 1 replaces One, replace = 2 replaces All
            object wrap = 1;
            
            string bookmarkStr;
            bool isFound = false;
            isFound = rngStory.Find.Execute(strSearch, matchCase, matchWholeWord,
                matchWildCards, matchSoundsLike, matchAllWordForms, forward, 
                wrap, format, replaceText, replace, matchKashida, 
                matchDiacritics, matchAlefHamza, matchControl);            
            
            if(isFound) {
            	rngStory.Select();
            	rngStory.Bookmarks.Add(bookmarkName, rngStory);
            	return true;
            }
            
            return false;
        }
