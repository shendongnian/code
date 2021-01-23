    private void SetTextDecorationsFromElement(FrameworkElement element)
    {
        SetUnderlineIsChecked = false;
        if (element.GetType().GetProperty("TextDecorations") != null)
        {
            var textdecoration = element.GetType().GetProperty("TextDecorations").GetValue(element) as TextDecorationCollection;
            SetUnderlineIsChecked =
                textdecoration == null ? false :
                textdecoration == DependencyProperty.UnsetValue ? false :
                textdecoration != null && textdecoration.Count == 0 ? false :
                textdecoration != null && textdecoration[0].Location.ToString() == "Underline";
        }
    }
