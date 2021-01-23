    using (var wordDoc = WordprocessingDocument.Open(@"c:\test\test.docx", true))
    {
    	MainDocumentPart mainPart = wordDoc.MainDocumentPart;
    
    	var runs = mainPart.Document.Descendants<Run>().ToList();
    
        foreach (Run run in runs)
        {
            var text = run.GetFirstChild<Text>();
            if(text.Text.Contains("KEYWORD"))
            {
                string[] words = text.Text.Split(' ');
                for(int i = 0; i < words.Count(); i++)
                {
                    string word = words[i];
                    var newRun = (Run)run.Clone();
                    string newWord = word + (i < words.Count() ? " " : "");
                    Text newRunText = newRun.GetFirstChild<Text>();
                    newRunText.Space = SpaceProcessingModeValues.Preserve;
                    newRunText.Text = newWord;
                    run.Parent.InsertBefore(newRun, run);
                }
                run.Remove();
            }
        }
    }
