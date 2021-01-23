    private void buttonGetTheText_Click(object sender, EventArgs e)
    {
        labelText.Text = "No text found.";
        IUIAutomation uiAutomation = new CUIAutomation8();
        Point ptCursor = Cursor.Position;
        tagPOINT pt;
        pt.x = ptCursor.X;
        pt.y = ptCursor.Y;
        // Cache the Text pattern that's available through the element beneath
        // the mouse cursor, (if the Text pattern's supported by the element,) in
        // order to avoid another cross-process call to get the pattern later.
        int patternIdText = 10014; // UIA_TextPatternId
        IUIAutomationCacheRequest cacheRequestTextPattern =
            uiAutomation.CreateCacheRequest();
        cacheRequestTextPattern.AddPattern(patternIdText);
        // Now get the element beneath the mouse.
        IUIAutomationElement element = 
            uiAutomation.ElementFromPointBuildCache(pt, cacheRequestTextPattern);
        // Does the element support the Text pattern?
        IUIAutomationTextPattern textPattern =
            element.GetCachedPattern(patternIdText);
        if (textPattern != null)
        {
            // Now get the degenerative TextRange where the mouse is.
            IUIAutomationTextRange range = textPattern.RangeFromPoint(pt);
            if (range != null)
            {
                // Expand the range to include the word surrounding 
                // the point where the mouse is.
                range.ExpandToEnclosingUnit(TextUnit.TextUnit_Word);
                // Show the word in the test app.
                labelText.Text = "Text is: \"" + range.GetText(256) + "\"";
            }
        }
    }
