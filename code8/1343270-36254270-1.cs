    string someString = "the girl is pretty";
    StringBuilder sb = new StringBuilder();
    bool uppercase = false;
    foreach (char c in someString)
    {
        if (uppercase)
            sb.Append(char.ToUpper(c));
        else
            sb.Append(char.ToLower(c));
        uppercase = !uppercase;
    }
    string newString = sb.ToString();
