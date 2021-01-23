    TextBox tb = new TextBox();
    tb.SpellCheck.IsEnabled = true;
    tb.Text = @"I am looking for ways to automatically fix a word if the word is miss spelled and seems to be a combination of two words. For example ""considerationof"" should be ""consideration of"". Any lead or any example will be greatly appreciated. Thanks!";
    var spellingErrorIndex = tb.Text.Length;
    do
    {
                
        var spellingError = tb.GetSpellingError(spellingErrorIndex);
        if (spellingError != null)
        {
            var suggestions = spellingError.Suggestions;    //suggests "consideration of"
            spellingError.Correct(suggestions.First());
        }
                
        spellingErrorIndex = tb.GetNextSpellingErrorCharacterIndex(spellingErrorIndex, LogicalDirection.Backward);
    } while (spellingErrorIndex >= 0);
