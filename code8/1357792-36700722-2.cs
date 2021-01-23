    public static void CreateText(string mas)
    {
        if (text.Length <= 80)
        {
            StringBuilder str;
            int count;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] >= '0' && mas[i] <= '9')
                    count += (mas[i] - '0');
                else
                {
                    if (count == 0)
                        str.Append(mas[i]);
                    else
                    {
                        for (int j = 0; j < count; j++)
                              str.Append(mas[i]);
                        count = 0;
                    }
                }
            }
            Console.WriteLine(str.ToString());
        }
        else
            Console.WriteLine("Error");
    }
