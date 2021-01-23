    public string FirstLetters(string s)
    {
        return String.Join("", s.Trim().Split(' ').Select(w => w.Substring(0, 1).ToUpper()));
    }
    var result = FirstLetter(txtCompanyname.Text);
