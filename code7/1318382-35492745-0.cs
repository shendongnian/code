        protected string ParseContent(string content)
        {
            if (content != null)
            {
                //Create a new document parser object
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                //load the content
                document.LoadHtml(content);
                //Get all embed tags
                List<HtmlNode> embedNodes = document.DocumentNode.Descendants("embed").ToList();
                //Make sure the content contains at least one <embed> tag
                if (embedNodes.Count() > 0)
                {
                    // Outputs the href for external links
                    foreach (HtmlNode embedNode in embedNodes)
                    {
                        //Mak sure there is a source
                        if (embedNode.Attributes.Contains("src"))
                        {
                            if (embedNode.Attributes["src"].Value.EndsWith(".html"))
                            {
                                //At this point we know that the source of the embed tag is set and it is an html file
 
                                //Get the full path
                                string embedPath = customBase + embedNode.Attributes["src"].Value;
                                //Get the 
                                string newContent = GetContent(embedPath);
                                if (newContent != null)
                                {
                                    //Create place holder div node
                                    HtmlNode newNode = document.CreateElement("div");
                                    //At this point we know the file exists, load it's content
                                    newNode.InnerHtml = HtmlDocument.HtmlEncode(newContent);
                                    //Here I need to be able to replace the entireembedNode with the newContent
                                    document.DocumentNode.InsertAfter(newNode, embedNode);
                                    //Remove the code after converting it
                                    embedNode.Remove();
                                }
                            }
                        }
                    }
                    return document.DocumentNode.OuterHtml;
                }
                return content;
            }
            return null;
        }
