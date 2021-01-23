    foreach (IHTMLElement element in htmlDoc.all)
    {
        var input = element as IHTMLInputImage;
        if (input != null && Path.GetFileName(input.src).Equals("icon_go.GIF", StringComparison.OrdinalIgnoreCase))
        {
            ((IHTMLElement)input).click();
        }
    }
