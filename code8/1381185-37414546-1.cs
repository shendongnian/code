    string result = "";
    foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("div"))
        if (el.GetAttribute("className") == "not-annotated hover")
        {
            result = el.InnerText;
            if (result.IndexOf("Ship Date") == 0) //Ship Date text is present in the string
            {
                //since the string format is Ship Date: July 17, 2015 -
                //we can assume : as a delimiter and split the text
                string[] splitText = result.Split(':');
                string date = splitText[1].Trim(); //this will give the date portion alone
            }
            textBox2.Text = result;
       }
