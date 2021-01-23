            string rmv = ""; string remove = "";
            int i = 0; int k = 0;
        A:
            rmv = "";
            for (i = k; i < s.Length; i++)
            {
                if (Convert.ToString(s[i]) == ":")
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (Convert.ToString(s[j]) != ":")
                        {
                            rmv += s[j];
                        }
                        else
                        {
                            remove += rmv + ",";
                            i = j;
                            k = j + 1;
                            goto A;
                        }
                    }
                }
            }
            string[] str = remove.Split(',');
            for (int x = 0; x < str.Length-1; x++)
            {
                s = s.Replace(Convert.ToString(":" + str[x] + ":"), "");
            }
            Console.WriteLine(s);
            Console.ReadKey();
