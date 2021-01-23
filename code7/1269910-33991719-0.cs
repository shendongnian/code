            string s = "the ball eat a boy >.<";
            string[] st = s.Split(' ');
            foreach (var str in st)
            {
                foreach (DataRow rows in dt.Rows)
                {
 
                    if(str == rows["Article"].ToString())
                        Console.WriteLine("Word=" + str + "    Column=Article");
                    else if (str == rows["Noun"].ToString())
                        Console.WriteLine("Word=" + str + "    Column=Noun");
                    else if (str == rows["Verb"].ToString())
                        Console.WriteLine("Word=" + str + "    Column=Verb");
                }
            }
