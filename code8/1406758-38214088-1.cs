    static string Solve(List<object> source, string prefix = "")
    {
        int itemIndex = 0;
        StringBuilder result = new StringBuilder();
        foreach (object item in source)
        {
            List<object> listItem = item as List<object>;
            if (listItem != null)
            {
                result.Append(Solve(listItem, prefix + itemIndex + "."));
            }
            else
            {
                itemIndex++;
                result.AppendLine(prefix + itemIndex + " " + item);
            }
        }
        return result.ToString();
    }
