    public void ColorValueExtraction()//Processing all colors values
    {
        StringBuilder sb = new StringBuilder(); //Creating a StringBuilder object to append later
        string ColorsWithBrackets = string.Empty;
        foreach (var data in ValidFiles) //data means a file - lots of text
        {
            
            Regex ValuesRegex = new Regex("HDMZones(.*)>>"); //Extracting only content between HDMZones and >>
            var RegexAux2 = ValuesRegex.Match(data); //Match my pattern on data
            ColorsWithBrackets = RegexAux2.Groups[1].ToString();
            ColorsWithBrackets = ColorsWithBrackets.Replace("HDMZones <</", "").Replace("<</", "").Replace("/", ""); //Replacing a few things
            var pattern = @"\[(.*?)\]"; //Extract numbers and brackets only
            var query = ColorsWithBrackets;
            
            var matches = Regex.Matches(query, pattern);
            foreach (Match m in matches) //Looping on matches ,numbers found
            {                   
                string aux2 = string.Empty; //auxiliar string 
                aux2 = m.Groups[1].ToString();//auxiliar string receives the match to string
                aux2 = Regex.Replace(aux2, @"\s+", "|");  //replacing all spaces with | , to be used as delimiter in other method               
                sb.Append(aux2); //each iteration appends to StringBuilder aux2 - so, in the end, sb will have all numbers from the respective file                                     
            }               
            HDMZonesNumbersLst.Add(sb.ToString()); //Adding each collection of numbers to a position in the list
        }           
    }
