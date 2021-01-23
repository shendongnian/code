    public bool IsStringInvalid(string text)
            {
                
                    if (text != null && text.Length > 4 && !Regex.IsMatch(text, textCodeFormat))
                    {
                        return true;
                    }
    
                        return false;
      
            }
