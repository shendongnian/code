    private void OnCalculateClick(object sender, EventArgs args)
    {
        int start = 0;
        int length = 0;
    
        List<string> tokens = new List<string>();
    
        foreach (object lineMetrics in GetLineMetrics(txt))
        {
            length = GetLength(lineMetrics);
            tokens.Add(txt.Text.Substring(start, length));
    
            start += length;
        }
    
        Result.Text = String.Join(Environment.NewLine, tokens);
    }
    
    private int GetLength(object lineMetrics)
    {
        PropertyInfo propertyInfo = lineMetrics.GetType().GetProperty("Length", BindingFlags.Instance
            | BindingFlags.NonPublic);
    
        return (int)propertyInfo.GetValue(lineMetrics, null);
    }
    
    private IEnumerable GetLineMetrics(TextBlock textBlock)
    {
        ArrayList metrics = new ArrayList();
        FieldInfo fieldInfo = typeof(TextBlock).GetField("_firstLine", BindingFlags.Instance
            | BindingFlags.NonPublic);
        metrics.Add(fieldInfo.GetValue(textBlock));
    
        fieldInfo = typeof(TextBlock).GetField("_subsequentLines", BindingFlags.Instance
            | BindingFlags.NonPublic);
    
        object nextLines = fieldInfo.GetValue(textBlock);
        if (nextLines != null)
        {
            metrics.AddRange((ICollection)nextLines);
        }
    
        return metrics;
    }
