    var caretPosition = richTextBox.CaretPosition;
    // Make sure you're passing a textpointer at the end of the word you want to correct, i.e. not like this ;)
    errorPosition = richTextBox.GetNextSpellingErrorPosition(caretPosition, LogicalDirection.Backward);
    if(errorPosition == null)
    {
        return;
    }
    
    var errors = richTextBox.GetSpellingError(errorPosition);
    // Default would be to only replace the text if there is one available replacement
    // but you can also measure which one is most likely with a simple string comparison
    // algorithm, e.g. Levenshtein distance
    if (errors.Suggestions.Count() == 1) 
    {
        var incorrectTextRange = richTextBox.GetSpellingErrorRange(errorPosition);
        var correctText = error.Suggestions.First();
        var incorrectText = incorrectTextRange.Text;
        
        // Correct the text with the chosen word...
        errors.Correct(correctText);
    }
    // Set caret position...
