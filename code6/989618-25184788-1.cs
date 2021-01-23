    public static string[] SplitStrings(string inboundString, char splitChar)
         {
            if(inboundString.Contains(splitChar))
            {
                return inboundString.Split(splitChar);
            }
            else 
            {
              return new string[] {};
            }
        }
