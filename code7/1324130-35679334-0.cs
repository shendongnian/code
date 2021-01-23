    public string convert_string_to_no(string val)
        {
            string str_val = "";
            int val_len = val.Length;
            for (int i = 0; i < val_len; i++)
            {
                char myChar = Convert.ToChar(val.Substring(i, 1));
                if ((char.IsDigit(myChar) == true) && (myChar == '-'))
                {
                     str_val +=  myChar; 
                }
            }
            return str_val;
        } 
