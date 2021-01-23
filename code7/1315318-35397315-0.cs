    public static Rect GetPreviousArrangeRect(UIElement element)
    {
        Type elementType;
        PropertyInfo propertyInfo;
    
        if (element != null)
        {
            elementType = element.GetType();
            propertyInfo = elementType.GetProperty("PreviousArrangeRect",
                BindingFlags.Instance | BindingFlags.NonPublic);
    
            return (Rect)propertyInfo.GetValue(element, null);
        }
    
        return Rect.Empty;
    }
