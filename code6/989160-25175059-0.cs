        List<string> nets_List = new List<string>() { "A", "B", "C" };
        var netListEnumType = GenerateEnumerations(nets_List, "netsenum");
        var typeName = netListEnumType.Name; // returns "netsenum" 
        var typeTypeName = netListEnumType.GetType().Name; // returns "RuntimeType", the actual name of the instantiated Type class.
        foreach (var enumName in nets_List)
        {
            var enumValBoxed = Enum.Parse(netListEnumType, enumName);
            Console.WriteLine(enumValBoxed.ToString()); // Writes "A", "B" and "C"
            Debug.Assert(enumValBoxed.GetType() == netListEnumType); // no assert yay.
        }
