     public static List<SearchedItem> ItemSearchResponse(string url)
        {
            List<SearchedItem> searchedItems = new List<SearchedItem>();
            WebRequest request = HttpWebRequest.Create(url);
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            XmlDocument doc = new XmlDocument();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            doc.LoadXml(reader.ReadToEnd());
            XmlNodeList listIsValid = doc.GetElementsByTagName("IsValid");
            if (listIsValid.Count > 0 && listIsValid[0].InnerXml == "True")
            {
                XmlNodeList listItems = doc.GetElementsByTagName("Item");
                foreach (XmlNode nodeItem in listItems)
                {
                    SearchedItem searchedItem = new SearchedItem();
                    foreach (XmlNode nodeChild in nodeItem.ChildNodes)
                    {
                        if (nodeChild.Name == "DetailPageURL")
                        {
                            searchedItem.DetailPageURL = nodeChild.InnerText;
                        }
                        else if (nodeChild.Name == "SmallImage")
                        {
                            foreach (XmlNode nodeURLImg in nodeChild.ChildNodes)
                            {
                                if (nodeURLImg.Name == "URL")
                                {
                                    searchedItem.SmallImage = nodeURLImg.InnerText;
                                }
                            }
                        }
                        else if (nodeChild.Name == "ItemAttributes")
                        {
                            foreach (XmlNode nodeItemAtributes in nodeChild.ChildNodes)
                            {
                                if (nodeItemAtributes.Name == "Title")
                                {
                                    searchedItem.Title = nodeItemAtributes.InnerText;
                                }
                            }
                        }
                        else if (nodeChild.Name == "OfferSummary")
                        {
                            foreach (XmlNode nodeOfferSummary in nodeChild.ChildNodes)
                            {
                                if (nodeOfferSummary.Name == "LowestNewPrice")
                                {
                                    foreach (XmlNode nodeLowestNewPrice in nodeOfferSummary.ChildNodes)
                                    {
                                        if (nodeLowestNewPrice.Name == "CurrencyCode")
                                        {
                                            searchedItem.CurrencyCode = nodeLowestNewPrice.InnerText;
                                        }
                                        else if (nodeLowestNewPrice.Name == "FormattedPrice")
                                        {
                                            string price = nodeLowestNewPrice.InnerText.Remove(0, 1);
                                            searchedItem.Price = Double.Parse(price);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (nodeChild.Name == "CustomerReviews")
                        {
                            foreach (XmlNode nodeCustomerReview in nodeChild.ChildNodes)
                            {
                                if (nodeCustomerReview.Name == "Review")
                                {
                                    foreach (XmlNode nodeReview in nodeCustomerReview.ChildNodes)
                                    {
                                        if (nodeReview.Name == "Content")
                                        {
                                            searchedItem.CustomerReview = nodeReview.InnerText;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    searchedItems.Add(searchedItem);
                }
            }
                        return searchedItems;
        }
