            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.OptionFixNestedTags = true;
            doc.Load("damn.html");
            //First off we find the nodes we want to collect data from. Note that we are only looking for a singlenode compared to your code where you find all nodes
            //this could be cut down to selectnodes where we take all <li> tages with each div tag. But for simplicity.
            HtmlNodeCollection favoritesContent = doc.DocumentNode.SelectNodes("//div[@id='favoritesContent']/div[@class='personListWrapper']/div[@class='gamerList']/ul//li");
            foreach (HtmlNode x in favoritesContent)
            {
                //here we find the gamertag which is an attribute in <li> if <li> does not have that value
                //it will then return the deault value ""(empty string as specified)
                string gamerTag = x.GetAttributeValue("data-gamertag", "");
                HtmlNode temp = x.SelectSingleNode("./a[@class='gamerpicWrapper']/*/img[@class='favorite']");
                string srcOnPic = temp.GetAttributeValue("src", "not found");
                string realName = x.SelectSingleNode("./descendant::*//div[@class='realName']").InnerText;
                string primaryInfo = x.SelectSingleNode("./descendant::*//div[@class='primaryInfo']").InnerText;
                if (0 < x.SelectSingleNode("./div[@class='statusIcon']").InnerHtml.Length)
                {
                    bool online = true;
                }
            }
