    foreach (HtmlElement chat in wb.Document.GetElementsByTagName("input"))
    {
            if (chat != null &&chat.InnerText != null && chat.InnerText.Equals("Chat"))
            {
                chat.InvokeMember("Click");
                loggedIn = true;
                break;
            }
    }
