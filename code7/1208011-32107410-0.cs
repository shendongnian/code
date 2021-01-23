    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    public partial class test
    {
        // temp string
        String temp = string.Empty;
    
        // array of readed text
        char[] chars;
    
        // helper variable
        int found = 0;
    
        // compare list
        List<String> compare = new List<string>() { ",", ";", "." };
    
        // Stream Reader
        StreamReader reader = new StreamReader("file.txt");
    
        public string increaseText()
        {
            // Read next line if end of this line
            if (chars == null || (found > 0 && temp.Length >= chars.Length))
            {
                // read whole line
                chars = reader.ReadLine().ToCharArray();
            }
    
            // check every char
            for (int i = found; i < chars.Length; i++)
            {
                temp += chars[i].ToString();
    
                // if stop sign found, exit and return our string
                if (compare.Contains(chars[i].ToString()))
                {
                    found = i + 1;
                    break;
                }
            }
            return temp;
        }
    
        public string decreaseText()
        {
            // get all chars
            char[] compChars = temp.ToCharArray();
    
            // check every char
            for (int i = temp.Length-1; i > 0; i--)
            {
                // if stop sign found, decrease text
                if (compare.Contains(compChars[i-1].ToString()))
                {
                    found = i;
                    temp = temp.Substring(0, i);
                    break;
                }
            }
            return temp;
        }
    }
