    public static IEnumerable<dynamic> GetExpandoFromXml(string file, string descendantid)
    {
        var expandoFromXml = new List<dynamic>();
    
        var doc = XDocument.Load(file);
        var nodes = doc.Root.Descendants(descendantid);
    
        foreach (var element in doc.Root.Descendants(descendantid))
        {
            dynamic expandoObject = new ExpandoObject();
            var dictionary = expandoObject as IDictionary<string, object>;
            foreach (var child in element.Descendants())
            {
                if (child.Name.Namespace == "")
                    dictionary[child.Name.ToString()] = child.Value.Trim();
            }
            yield return expandoObject;
        }
    }
