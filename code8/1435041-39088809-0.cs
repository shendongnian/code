    public static string ShowTree(List<TreeModel> source)
    {
        var buffer = new StringBuilder();
        foreach (var item in source.Where(x => !x.ParentId.HasValue))
        {
            WriteTree(buffer, source, item);
        }
        
        return buffer.ToString();
    }
    private static void WriteTree(StringBuilder buffer, List<TreeModel> source, TreeModel item, int level = 0)
    {
        buffer.AppendLine(new string('\t', level) + item.Name);
        foreach (var child in source.Where(x => x.ParentId == item.Id))
        {
            WriteTree(buffer, source, child, level + 1);
        }
    }
