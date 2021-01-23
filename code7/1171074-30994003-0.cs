    string s = "$";
                foreach (var c in s)
                {
                    var category = CharUnicodeInfo.GetUnicodeCategory(c);
    
                    if (category == UnicodeCategory.CurrencySymbol)
                    {
                        //Force convert the char to what every character you want
                    }
                }
