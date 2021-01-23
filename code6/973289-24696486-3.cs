    public static class TextBoxExtensions
    {
        public static void SetTextOrEmpty(this TextBox tb, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                tb.Text = value;
            else
                tb.Text = "";
    
        }
    }
