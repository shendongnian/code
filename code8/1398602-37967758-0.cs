    IEnumerable<XElement> filter(IEnumerable<XElement> source)
    {
        for (int counter = 0; counter < 5; counter++)
        {
            string index = (counter + 1).ToString();
            foreach (var n in source.Where(x =>
                {
                    var attr1 = x.Attribute("Attribute" + index);
                    var attr2 = x.Attribute("AttributeN" + index);
                    if (attr1 == null || attr2 == null)
                        return false;
                    return Regex.IsMatch("String" + index, attr1.Value)
                        && Regex.IsMatch("String" + index, attr2.Value);
                }))
            {
                yield return n;
            }
        };
    }
