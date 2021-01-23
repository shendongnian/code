	string str = "This is a test";
    foreach(char c in str)
    {
        char newChar = c;
        if (c != ' ')
        {
            string propName = string.Format("{0}_sub", c.ToString().ToLowerInvariant());
            var field = (new DummyClass()).GetType().GetField(propName);
            if(field != null)
            {
                newChar = field.GetValue(new DummyClass()).ToString().ToCharArray()[0];
            }
        }
        str = str.Replace(c, newChar);
    }
