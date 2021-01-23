    var text = txtTelephoneNumber.Text;
    bool valid;
    if (!String.IsNullOrEmpty(text))
    {
        valid = text.ElementAt(0) == '0' &&
                9 <= text.Count() && text.Count() <= 10 &&
                text.All(c => Char.IsDigit(c));
    }
    if (!valid)
    {
    }
    
