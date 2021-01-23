    var result2 = text.Split(" \r\n".ToCharArray(), 
            StringSplitOptions.RemoveEmptyEntries)?.Select(num => 
             { 
                double result;  
                if (!double.TryParse(num, out result))
                { // error set result to value other than zero if you need to }
                return result;
             }).OrderBy(d => d).ToArray();"
