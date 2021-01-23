    string text = "150 east 40th street";
    
    
    
                string[] array = text.Split(' ');
                    
    
                for (int i = 0; i < array.Length; i++)
                {
                    if (!Regex.IsMatch(array[i], @"^\d+"))
                    {
                        array[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(array[i]);
                    }
                }
                
    
                string newText = string.Join(" ",array);
