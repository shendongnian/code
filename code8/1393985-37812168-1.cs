    static class Namespaces
    {
        //You would then need to add a prop for each namespace you want
        static string Data = typeof(System.Data.Constrains).Namespace;
    }
    var namespaceA = typeof(System.Data.DataTable).Namespace
    if (namespaceA == Namespaces.Data) //true
    { 
        //do something
    }
