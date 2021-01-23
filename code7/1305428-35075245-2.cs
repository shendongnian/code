    foreach (var t : MyStringDictionary.GetType().GetInterfaces()) {
        Type keyType, valType;
        if (IsEnumKvp(t, out keyType, out valType)) {
            Console.WriteLine(
                "Your class implements IEnumerable<KeyValuePair<{0},{1}>>"
            ,   keyType.FullName
            ,   valType.FullName
            );
        }
    }
