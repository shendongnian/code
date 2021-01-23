    public static void GenerateCode(Node parentNode, IEnumerable<int> values)
    {
        if (parentNode != null)
        {
            string code = string.Concat(values);
            GenerateCode(parentNode.leftChild, Concat(values, 0));
    
            if (parentNode.leftChild == null && parentNode.rightChild == null)
                Console.WriteLine(parentNode.data + "{" + code + "}");
    
            GenerateCode(parentNode.rightChild, Concat(values, 1));
        }
    }
    private static IEnumerable<T> Concat(IEnumerable<T> coll, T obj)
    {
        foreach (var v in coll)
            yield return v;
        yield return obj;
    }
