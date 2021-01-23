    if (temp[0].Equals("plate"))
    {
        silvers.Add(childNodeAttrib.Attributes["name"].Value,
            new Plate 
            {
                Id = Convert.ToDouble(ruleElement.Attributes["silverid"].Value),
                Value = Convert.ToDouble(childNodeCond.InnerText)
            });
    }
