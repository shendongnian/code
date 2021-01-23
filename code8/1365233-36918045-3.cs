    XElement node;
    using (var enumerator = xmlFile.Descendants("SomeElement").GetEnumerator()) 
    {
        if (!enumerator.MoveNext()) 
        {
           throw new Exception(...); 
        }
        node = enumerator.Current;
    }
