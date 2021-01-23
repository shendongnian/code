    public static void GenerateCode(StringBuilder builder, Node parentNode, IEnumerable<int> values)
    {
        if (parentNode != null)
        {
            GenerateCode(builder, parentNode.leftChild, Concat(values, 0));
    
            if (parentNode.leftChild == null && parentNode.rightChild == null)
                builder.AppendLine(string.Format("{0}{{{1}}}", parentNode.data, string.Concat(values));
    
            GenerateCode(builder, parentNode.rightChild, Concat(values, 1));
        }
    }
    private static IEnumerable<T> Concat(IEnumerable<T> coll, T obj)
    {
        foreach (var v in coll)
            yield return v;
        yield return obj;
    }
