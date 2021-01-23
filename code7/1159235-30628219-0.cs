    public static string GetTextValue(this TextBoxBase source)
    {
        // need to cast TextBoxBase to one of its implementations
        var txtControl = source as TextBox;
        if (txtControl == null)
        {
            var txtControlRich = source as RichTextBox;
            if (txtControlRich == null) return null;
            return txtControlRich.Text;
        }
        
        return txtControl.Text;
    }
