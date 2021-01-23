    XElement xmla = XElement.Load("input.xml");
    var operations = from operation in xmla.Descendants("OPERATION")
                        select new Operation
                        {
                            Model = operation.Attribute("MODEL").Value,
                            SubModel = operation.Attribute("SUBMODEL").Value,
                            TagContent = operation.Value,
                            FullTag = operation.ToString(),
                        };
    foreach (var operation in operations)
    {
        Console.WriteLine(operation.Model + " - " + operation.SubModel+ " - " + operation.TagContent " - " + operation.FullTag);
    }
