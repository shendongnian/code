    string str = "This is a test";
    StringBuilder  result = new StringBuilder();
    for(int idx = 0; idx < str.Length; idx++)
    {
        char newChar = str[idx];
        if (newChar != ' ')
        {
            string propName = string.Format("{0}_sub", newChar.ToString().ToLowerInvariant());
            // program is the name of your class...
            var field = typeof(Program).GetField(propName);
            if(field != null)
            {
                // where null in case of static class
                //replace with the name of the class where the consts are
                newChar = field.GetValue(null).ToString().ToCharArray()[0];
            }
        }
        result.Append(newChar);
    }
    str = result.ToString();
