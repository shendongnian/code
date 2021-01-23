        SelectionItemPattern pattern;
        try
        {
            pattern = yourAutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);  // Most likely "Pattern not supported." 
            return;
        }
        pattern.Select();
