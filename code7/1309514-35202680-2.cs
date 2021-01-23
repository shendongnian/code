    var text = txtTelephoneNumber.Text;
    bool valid = false;
    if (!String.IsNullOrEmpty(text))
    {
        valid = text.First() == '0' &&
                9 <= text.Count() && text.Count() <= 10 &&
                text.All(c => Char.IsDigit(c));
    }
    if (!valid)
    {
    }
    
