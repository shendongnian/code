     public static bool IsNull(this string source)
                {
                    return string.IsNullOrWhiteSpace(source);
                }
     public static string IsNullOrSame(this string source, string comparer)
            {
                //check for both values are null 
                if (source.IsNull() && comparer.IsNull())
                {
                    return "Both Values Null or contain whitespace only";
                }
    
                //check if string 1 is null and string two has a value.
                if (source.IsNull() && !comparer.IsNull())
                {
                    return "I don't have a Value, but string 2 does";
                }
    
                //check if string 1 has a value and string two is null 
                if (!source.IsNull() && comparer.IsNull())
                {
                    return "I have Value, but string 2 doesn't";
                }
    
                //if we make it this far then both have a value,  check if the string value matches
                if(source.Trim().Equals(comparer.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return "Both value match"; 
                }
    
                //if values don't match
                return "strings both have values but don't match";
            }
  
