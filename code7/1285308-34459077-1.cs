    var div = webBrowser1.Document.GetElementById("ctl00_RightMainContent_submitAddress_p_submitButtom");
    if (div != null)
    {
        var button = div.All.Cast<HtmlElement>().Where(x =>
            !string.IsNullOrEmpty(x.GetAttribute("class")) &&
            x.GetAttribute("class").Contains("btn_send")).FirstOrDefault();
        if (button != null)
            button.InvokeMember("click");
        else
            MessageBox.Show("Button not found.");
    }
    else
    {
        MessageBox.Show("div not found.");
    }
