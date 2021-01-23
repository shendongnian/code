         string result = "";
            string date = "";
                 foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("div"))
                            if (el.GetAttribute("className") == "not-annotated hover")
                            {
                                result = el.InnerText;
                              date = Regex.Match(result , 
                              String.Format(@"{0}\s(?<words>[\w\s]+)\s{1}", "Ship Date:", "Country:"),
    RegexOptions.IgnoreCase).Groups["words"].Value;
                                    textBox2.Text = date ;
                             }
                
                
