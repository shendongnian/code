    foreach  (char c in fileContent) 
    {
            if (char.IsLetter(c))
            {
                occurrence[c] += 1;
            }
            else
            {
                if (c == ' ' || c == ',' || c == ':' || c == ';')
                {
                    occurrence[' '] += 1;
                }
            }
        }
    }
