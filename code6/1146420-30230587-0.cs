    XDocument XDocument = XDocument.Parse(MyXml);
    
    var nodes = XDocument.Descendants("item");
    
    // Get the type contained in the name string
    Type type = typeof(Person);
    
    // create an instance of that type
    object instance = Activator.CreateInstance(type);
    
    // iterate on all properties and set each value one by one
    
    foreach (var property in type.GetProperties())
    {
    
        // Set the value of the given property on the given instance
        if (nodes.Descendants("key").Any(x => x.Value == property.Name)) // check if Property is in the xml
        {
            // exists so pick the node
            var node = nodes.First(x => x.Descendants("key").First().Value == property.Name);  
            // set property value by converting to that type
            property.SetValue(instance,  Convert.ChangeType(node.Element("value").Value,property.PropertyType), null);
        }
    }
    
    
    var tempPerson = (Person) instance;
