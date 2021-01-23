    var xml = @"<?xml version='1.0' encoding='UTF-8'?>
    <root xmlns:test='urn:my-test-urn'>
        <Item name='Item one'>
            <test:AlternativeName>Another name</test:AlternativeName>
            <Price test:Currency='GBP'>124.00</Price>
        </Item>
    </root>";
    var doc = XDocument.Parse(xml);
    XNamespace test = "urn:my-test-urn";
    //get all elements in specific namespace and remove
    doc.Descendants()
       .Where(o => o.Name.Namespace == test)
       .Remove();
    //get all attributes in specific namespace and remove
    doc.Descendants()
       .Attributes()
       .Where(o => o.Name.Namespace == test)
       .Remove();
       
    //print result
    Console.WriteLine(doc.ToString());
