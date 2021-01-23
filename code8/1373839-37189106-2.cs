    static void DumpObjectTree(object propValue, int level = 0)
    {
        if (propValue == null)
            return;
        
        var childProps = propValue.GetType().GetProperties();
        foreach (var prop in childProps)
        {
            var name = prop.Name;
            var value = prop.GetValue(propValue, null);
            // add some left padding to make it look like a tree
            Console.WriteLine("".PadLeft(level * 4, ' ') + "{0}={1}", name, value);
            // call again for the child property
            DumpObjectTree(value, level + 1);
        }
    }
    // usage: DumpObjectTree(obj);
