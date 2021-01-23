    foreach(var userInfo in xdoc.Root.Elements("userInfo"))
    {
        var details = userInfo.Elements();
        if (details.Count() > 0)
        {
            foreach(var detail in details)
            {
                result.Append(detail.Value.Trim() + ", ");
            }
            result.Remove(result.Length - 2, 2).Append("\n");
        }
    }
