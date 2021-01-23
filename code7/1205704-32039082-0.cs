    int intValue;
    if (Int32.TryParse(str[7], out intValue)) 
    {
         //Do some thing with the int value
    }
    else
    {
         throw new Exception("Some informative error message, probably using string.Format to include the string you tried to parse");
    }
