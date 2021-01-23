    public static List<Field> getMailMergeFields(Document document)
    {
        List<Field> mailMergeFields = new List<Field>();
        foreach (Shape shape in document.Shapes)
        {
            if (shape.TextFrame.HasText != 0)
            {
                foreach (Field field in shape.TextFrame.ContainingRange.Fields)
                {
                    if (isMailMergeField(field)) mailMergeFields.Add(field);
                }
            }
        }
        foreach (Field field in document.Fields)
        {
            if (isMailMergeField(field)) mailMergeFields.Add(field);
        }
        return mailMergeFields;
    }
    public static bool isMailMergeField(Field field)
    {
        string fullField = field.Code.Text.Trim();
        if (!fullField.StartsWith("MERGEFIELD")) return false;
        if (!fullField.EndsWith(@"\* MERGEFORMAT")) return false;
        return true;
    }
