    var list1 = XElement.Parse(@"<root><Element name=""foo"">
                                    <ChildElement name=""childFoo"">
                                        <SubChildElement name=""subChildFoo"" />
                                    </ChildElement>
                                </Element>
                                <Element name=""bar"">
                                    <ChildElement name=""childBar"">
                                        <SubChildElement name=""subChildBar"" />
                                    </ChildElement>
                                </Element>
                                <Element name=""zoo"" /></root>");
    
    var list2 = XElement.Parse(@"<root><Element name=""foo"" attr=""fooAtr"" />
                                <Element name=""bar"" attr=""barAtr"" />
                                <Element name=""zoo"" attr=""barAtr"" /></root>");
    
    
    var elementsByName = list1.Descendants("Element")
        .ToDictionary(e => (string) e.Attribute("name"));
    
    foreach (var element in list2.Descendants("Element"))
    {
        var name = (string)element.Attribute("name");
        var relatedElement = elementsByName[name];
    
        element.Add(relatedElement.Elements());
    }
    
