    public static class TextBoxExtensions
    {
        public static string SetTextOrEmpty(this TextBox tb, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return tb.Text = value;
            else
                return tb.Text = "";
    
        }
    }
