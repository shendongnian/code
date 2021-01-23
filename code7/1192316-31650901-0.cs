    string inputHtmlContent = "<Your Html Content containing images goes here>";
                			string outputHtmlContent = string.Empty;
                            var myResources = new List<LinkedResource>();
                            
                			if ((!string.IsNullOrEmpty(inputHtmlContent)))
                            {
                                
                                var doc = new HtmlDocument();
                                doc.LoadHtml(inputHtmlContent);
                                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//img");
                                if (nodes !=null)
                				{
                					foreach (HtmlNode node in nodes)
                					{
                						if (node.Attributes.Contains("src"))
                						{
                							string data = node.Attributes["src"].Value;
                							string imgPath = System.Web.HttpContext.Current.Server.MapPath(data);
                							var imgLogo = new LinkedResource(imgPath);
                							imgLogo.ContentId = Guid.NewGuid().ToString();
                							imgLogo.ContentType = new ContentType("image/jpeg");
                							myResources.Add(imgLogo);
                							node.Attributes["src"].Value = string.Format("cid:{0}", imgLogo.ContentId);
                							outputHtmlContent = doc.DocumentNode.OuterHtml;
                						}
                					}
                				}
                				else
                				{
                					outputHtmlContent = inputHtmlContent;
                				}
                                AlternateView av2 = AlternateView.CreateAlternateViewFromString(outputHtmlContent,
                                    null, MediaTypeNames.Text.Html);
                                foreach (LinkedResource linkedResource in myResources)
                                {
                                    av2.LinkedResources.Add(linkedResource);
                                }
            var msg = new MailMessage();
                            msg.AlternateViews.Add(av2);
                            msg.IsBodyHtml = true;
        <-- Enter Other required Informations and send mail -->
        ...
                          }
