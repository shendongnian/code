    var namespaceA = typeof(YourNamespace.Part1.ClassA()).Namespace;
    var namespaceB = typeof(YourNamespace.Part2.ClassB()).Namespace;
    if (namespaceA == namespaceB) //false
    { 
        //do something
    }
