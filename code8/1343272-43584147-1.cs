    string someString = "the girl is pretty";
    string space = " ";
    char[] str = someString.ToCharArray();
    char[] str2 = space.ToCharArray();
    bool uppercase = false;
    StringBuilder sb = new StringBuilder();
    foreach (char c in str)
    {
        if (c != str2[0])
        {
            if (uppercase)
                sb.Append(char.ToUpper(c));
            else
            {
                sb.Append(char.ToLower(c));
            }
            uppercase = !uppercase;
        }
        else
        {
            sb.Append(c);
        }   
    }
    string newString = sb.ToString();
