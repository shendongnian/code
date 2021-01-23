    public String RetrieveClipboardHtmlText(String replacementHtmlText)
    {
        String returnHtmlText = null;
        if (Clipboard.ContainsText(TextDataFormat.Html))
        {
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html);
        }
        return returnHtmlText;
    }
