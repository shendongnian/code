            string xpath = "//tr[@class='bk']";
            HtmlNodeCollection matches = htmlDoc.DocumentNode.SelectNodes(xpath);
            List<List<string>> footballMatches = new List<List<string>>();
            foreach (HtmlNode x in matches)
            {
                List<string> mess = new List<string>();
                HtmlNodeCollection hTC = x.SelectNodes("./td");
                if (hTC.Count > 15)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (i != 5)
                        {
                            mess.Add(hTC[i].InnerText);
                        }
                    }
                }
                footballMatches.Add(mess);
            }
