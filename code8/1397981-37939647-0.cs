    buttonLinkObject.Font.Underline = true;
    FontInfo fontInfo = buttonLinkObject.GetType().GetProperty("Font").GetValue(buttonLinkObject, null) as FontInfo;
    if (fontInfo != null)
    {
        bool isUnderline = fontInfo.Underline;
    }
