    public void buttonClick(string type) {
        var btn = yourWeb.Document.GetElementsByTagName("button")
                 .Cast<HtmlElement>()
                 .FirstOrDefault(m => m.GetAttribute("type") == type);
        if (btn != null)
            btn.InvokeMember("click"); 
    }
