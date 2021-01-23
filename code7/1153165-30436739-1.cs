    public static bool MyIP(string value)
        {
            var x = value.Split('.');
            if (!(x.Length==4)) 
               return false;
    
            foreach(var i in x) 
            {
                int q;
                if (!Int32.TryParse(x, out q)||q.ToString().Length.Equals(y.Length) 
                    || q < 0 || q > 255) 
                { 
                   return false;  
                }
    
            }
    
            return true;
        }
