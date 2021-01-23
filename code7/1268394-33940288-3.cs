    Assembly assembly = ... // Your Assemblie which contains plugin 
    // XmlSerializer needs all possible types to Deserialize an interface 
    var possibleTypes = assembly.GetTypes().Where(t => t.IsClass && t.IsAssignableFrom(typeof(IAmPlugin))).ToArray(); 
    XmlSerializer serializer = new XmlSerializer(typeof(IAmPlugin), possibleTypes);
    object value = valueSerializer.Deserialize(reader);
