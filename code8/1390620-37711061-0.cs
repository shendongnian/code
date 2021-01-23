     public static class StringExtensions
            {
             
                public static bool CheckIsNullOrEmptyAndListIt(this string field, string fieldName, List<string> naughties)
                {
                    var result = String.IsNullOrEmpty(field);
                    if (result == true)
                    {
                        naughties.Add(fieldName);
                    }
    
                    return result;
                }         
            }
        }
