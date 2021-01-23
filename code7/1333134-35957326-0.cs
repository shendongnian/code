    var results = doc.Descendants("book").Where(d => IsMatched(d, searchCriteria).Select(x => new BookModel()
            {
                Author = (string)x.Element("author"),
                Title = (string)x.Element("title"),
                Genre = (string)x.Element("genre"),
                Price = (decimal)x.Element("price"),
                PublishDate = (DateTime)x.Element("publish_date"),
                Description = (string)x.Element("description")
            }).ToList();
    public bool IsMatched(XElement node, Dictionary<string, string> searchCriteria)
        {
            foreach (var key in criteras)
            {
                if (node.Element(key.Key).Value != key.Value)
                {
                    return false;
                }
            }
            return true;
        }
