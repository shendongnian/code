    XNamespace newNs= "http://www.w3.org/1998/Math/MathML";
    var xDoc = XDocument.Load(<yourxml>);
    var maths = xDoc.Descendants("math").ToList();
    foreach (var math in maths){
        //remove old namespace (well, all attributes with this code)
        math.RemoveAttributes();
        //change the namespace
        foreach (var m in math .DescendantsAndSelf())
              m.Name = newNs + m.Name.LocalName;
        //add the display attribute depending on parent
        if (math.Parent.Name == "InlineEquation")
            math.SetAttributeValue("display", "block");
    
        if (math.Parent.Name == "Equation")
            math.SetAttributeValue("display", "inline");
        //replace parent node by math node
        math.Parent.ReplaceWith(newNode);
    }
