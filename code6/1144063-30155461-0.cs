                        XNamespace ns2 = "xmlns:xlink=" + "http://www.w3.org/1999/xlink";
                        var urlChildNode = new XElement( ns2 + "Redirect");
                        rootNode.Add(urlChildNode);
                        var urlOldNode = new XElement(ns2 + "key", oldUrl.Replace(hostName, ""));
                        urlChildNode.Add(urlOldNode);
                        if (newUrl.Equals(hostName + "/"))
                        {
                            var urlNewNode = new XElement(ns2 + "value", newUrl.Replace(hostName + "/", "/"));
                            urlChildNode.Add(urlNewNode);
                        }
                        else if (newUrl.Equals(hostName))
                        {
                            var urlNewNode = new XElement(ns2 + "value", newUrl.Replace(hostName, "/"));
                            urlChildNode.Add(urlNewNode);
                        }
                        else if (newUrl.Equals("www.aircharterservice.com"))
                        {
                            var urlNewNode = new XElement(ns2 + "value", newUrl.Replace("www.aircharterservice.com", "/"));
                            urlChildNode.Add(urlNewNode);
                        }
                        else
                        {
                            var urlNewNode = new XElement(ns2 + "value", newUrl.Replace(hostName, ""));
                            urlChildNode.Add(urlNewNode);
                        }
