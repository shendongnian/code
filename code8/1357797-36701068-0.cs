    public static void CreateText(string text)
    {
        if (text != null && text.Length <= 80)
        {
            int n; int count = 0;
            StringBuilder result = new StringBuilder();
            char[] mas = text.ToCharArray();
    
            foreach(char c in text)
            {
                if (int.TryParse(c.ToString(), out n))
                {
                    count = (count * 10) + n;
                }
                else
                {
                    if (count == 0) 
                    { 
                        result.Append(c);
                    }
                    else
                    {
                        result.Append(new string(c, count));
                        count = 0;
                    }
                }
    
            }
            Console.WriteLine(result.ToString());
        } else {
            Console.WriteLine("Error");
        }
    }
