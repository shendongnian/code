    public float GetValue(string logoName = "LogoSpec", string layout = "Web", string paperSize = "A4", string property = "Height")
    {
        Type logoType = Type.GetType(logoName);
        Type layoutType = logoType?.GetNestedType(layout);
        Type paperType = layoutType?.GetNestedType(paperSize);
        PropertyInfo pi = paperType?.GetProperty("Height", BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
        return (float?)pi?.GetValue(null) ?? 0f;
    }
