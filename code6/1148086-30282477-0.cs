          data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
          Console.WriteLine(StripExtended(data));        
    
    
    
            static string StripExtended(string arg)
            {
                StringBuilder buffer = new StringBuilder(arg.Length); //Max length
                foreach(char ch in arg)
                {
                    UInt16 num = Convert.ToUInt16(ch);//In .NET, chars are UTF-16
                    //The basic characters have the same code points as ASCII, and the extended characters are bigger
                    if((num >= 32u) && (num <= 126u)) buffer.Append(ch);
                }
                return buffer.ToString();
            }
        }
    }
