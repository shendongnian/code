        var fileData = XElement.Load(srcFile1);
        var xElement1 = fileData.Element("FoobarFoos");
        if (xElement1 != null)
        {
            var element1 = xElement1.Element("Foo");
            if (element1 != null)
            {
                var xElement =
                    element1.Element("FooVariables");
                if (xElement != null)
                {
                    var variableCollection = 
                        from element in fileData.Descendants("FooVariable")
                        where (string) element.Attribute("VariableName").Value == "Country"
                        select element;
                }
            }
        }
