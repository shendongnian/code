    foreach (var lv1 in lv1s)
    {
        result.AppendLine(lv1.Header);
        foreach (var lv2 in lv1.Children)
        {
            //result.AppendLine("     " + lv2.Attribute("type").Value); // THERE ARE NO ATTRIBUTES
            result.AppendLine("     " + lv2.Value);
        }
    }
