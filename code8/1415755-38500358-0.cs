    XNamespace mathMl = "http://www.w3.org/1998/Math/MathML";
    
    var doc = XDocument.Parse(xml);
    
    foreach (var equation in doc.Descendants("InlineEquation").ToList())
    {
        foreach (var math in equation.Elements("math"))
        {
            math.Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
            math.SetAttributeValue("display", "block");
    
            foreach (var element in math.DescendantsAndSelf())
            {
                element.Name = mathMl + element.Name.LocalName;
            }               
        }
    
        equation.ReplaceWith(equation.Nodes());            
    }
