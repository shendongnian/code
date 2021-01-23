    foreach (HtmlElement chat in wb.Document.GetElementsByTagName("input"))
    {
        if (chat != null && (!chat.isEmpty())&& chat!="")
        {
            if (chat.InnerText.Equals("Chat"))
            {
                chat.InvokeMember("Click");
                loggedIn = true;
                break;
            }
        }
    }
