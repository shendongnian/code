    XElement _atom = XElement.Load(atom);
            XNamespace nsMedia = "http://search.yahoo.com/mrss/";
            XNamespace nsAtom = "http://www.w3.org/2005/Atom";
            var temp = (from item in _atom.Descendants(nsAtom + "entry")
                        select new 
                        {
                            Title = item.Element(nsAtom + "title") == null ? "" : item.Element(nsAtom + "title").Value,
                            Description = item.Element(nsAtom + "summary") == null ? "" : item.Element(nsAtom + "summary").Value,
                            PublishedDate = item.Element(nsAtom + "published") == null ? "" : item.Element(nsAtom + "published").Value,
                            Link = item.Element(nsAtom + "link") == null ? "" : item.Element(nsAtom + "link").Attribute("href") == null ? "" : item.Element(nsAtom + "link").Attribute("href").Value,
                            Image = item.Element(nsMedia + "thumbnail") == null ? "" : item.Element(nsMedia + "thumbnail").Attribute("url") != null ? item.Element(nsMedia + "thumbnail").Attribute("url").Value : ""                           
                        }).ToList();
