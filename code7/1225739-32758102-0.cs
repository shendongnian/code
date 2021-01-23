    try
    {
        // Loop through each footnote in the word doc.
        foreach (Footnote rngWord in Microsoft.Office.Interop.Word.Application.ActiveDocument.Content.Footnotes)
        {
            // For each paragraph in the footnote - set the indentation.
            foreach (Paragraph parag in rngWord.Range.Paragraphs)
            {
                // If this was not previously indented (i.e. FirstLineIndent is zero), then indent.
                if (parag.Range.ParagraphFormat.FirstLineIndent == 0)
                {
                    // Set hanging indent.
                    rngWord.Range.ParagraphFormat.TabHangingIndent(1);
                }
                else
                {
                    // Remove hanging indent.
                    rngWord.Range.ParagraphFormat.TabHangingIndent(-1);
                }
            }
        }
        // Force the screen to refresh so we see the changes.
        Microsoft.Office.Interop.Word.Application.ScreenRefresh();
                    
    }
    catch (Exception ex)
    {
        // Catch any exception and swollow it (i.e. do nothing with it).
        //MessageBox.Show(ex.Message);
    }
