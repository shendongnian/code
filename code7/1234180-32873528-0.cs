    private bool IsNumber(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches if the text contains only numbers
            return regex.IsMatch(text);
        }
