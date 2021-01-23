    public static class ExcelExtensions
        {
            public static exc.Range Named(this exc.Range Cells, string CellName)
            {
                //Get Letter
                char[] charArray = CellName.ToCharArray();
                string strLetter = string.Empty;
                foreach (char letter in charArray) 
                {
                   
                    if (Char.IsLetter(letter)) strLetter += letter.ToString();
                  
                }
                
                //Convert Letter to Number
    
                double value = 0;
    
                if (strLetter.Length > 1)
                {
    
                    foreach (char letter in strLetter) 
                    {
                        if (value == 0)
                        {
                            value = (letter - 'A' + 1) * Math.Pow(26, (strLetter.Length -1));
                        }
                        else
                        {
                            value += (letter - 'A' + 1);
                        }
    
                    }
                }
                
                else
                {
                    char[] letterarray = strLetter.ToCharArray();
                    value = (letterarray[0] - 'A') + 1;
    
                }
    
                // ReadOut Number
    
                string strNumber = string.Empty;
                foreach (char numChar in CellName.ToCharArray()) 
                {
                    if (Char.IsNumber(numChar)) strNumber += numChar.ToString();
                    
                }            
                
                return Cells[strNumber, value];
               
            }
        }
