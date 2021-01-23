     private void Application_DocumentOpen(Microsoft.Office.Interop.Word.Document doc)
      {
                //Test revisions
        // expected text, as taken from screengrab example above. Includes
        //  text removed in a revision
        string expectedText = "Video provides a powerful way to help you prove your point.";
    
        // make sure that we're in print view
        if (doc.ActiveWindow.View.Type != Word.WdViewType.wdPrintView)
        {
            doc.ActiveWindow.View.Type = Word.WdViewType.wdPrintView;
        }
    
        // attempt to ensure that document revisions are marked up inline. Does not accomplish anything
        Word.View vw = doc.ActiveWindow.View;
        vw.MarkupMode = Word.WdRevisionsMode.wdInLineRevisions;
        vw.RevisionsView = Word.WdRevisionsView.wdRevisionsViewFinal;      
        // attempt to locate text. Will fail if revisions are not marked up inline (deletion is not part of document content range otherwise)
        var locatedRange = OccurrenceOfText(doc.Content, expectedText);
    }
    
    // extension method to locate text inside a range. Searching entire Content in this example
    private static Word.Range OccurrenceOfText(Word.Range rng, string text)
    {
        rng.Find.Forward = true;
        rng.Find.Format = false;
    
        rng.Find.Execute(text);
    
        if (!rng.Find.Found)
        {
            throw new Exception("Unable to locate text! Are Revisions marked up inline?");
        }
    
        // return brand new range containing located content
        return rng;  //.Document.Range(rng.Start, rng.End);
     }
