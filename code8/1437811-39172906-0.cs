    public static string SerializeXelement(Action<XElement, IEnumerable<string>> xmlProcessor, XElement xEl, IEnumerable<string> ensureNodeArray = null, 
        bool removeAttrSymbol = true, Formatting formatting = Formatting.None, bool omitRootObject = false)
    {
        if (xmlProcessor != null)
        {
            xmlProcessor(xEl, ensureNodeArray);
        }
    
        var output = JsonConvert.SerializeXNode(xEl, formatting, omitRootObject);
        if (removeAttrSymbol) { output = output.RemoveJsonXmlAttributeSymbols(); }
        return output;
    }
