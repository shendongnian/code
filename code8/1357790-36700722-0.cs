    public static void CreateText(string text)
    {
        if (text.Length <= 80)
        {
            int n;
            StringBuilder str;
            int count;
            char[] mas = text.ToCharArray();
    
            for (int i = 0; i < mas.Length; i++)
            {
                if (int.TryParse(mas[i].ToString(), out n))
                    count.Append(mas[i]);
                else
                {
                    if (count == 0)
                        str.Append(mas[i]);
                    else
                    {
                        for (int j = 0; j < count; j++)
                              str.Append(mas[i]);
                        count.Clear();
                    }
                }
            }
            Console.WriteLine(str.ToString());
        }
        else
            Console.WriteLine("Error");
    }
