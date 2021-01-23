    Console.WriteLine("Kindly provide input");
                string DayInWeek = Console.ReadLine();
                string[] GetDays = DayInWeek.Split(',');
                Array.Sort(GetDays);
                DateTime dt = DateTime.Today;
                int i = (int)dt.DayOfWeek;
                Console.WriteLine("Today is " + (DayOfWeek)i);
                bool flag = false;
                foreach (string FirstDay in GetDays)
                {
                    if (Convert.ToInt32(FirstDay) > i)
                    {
                        Console.WriteLine((DayOfWeek)Convert.ToInt32(FirstDay) + " is the next day");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine((DayOfWeek)Convert.ToInt32(GetDays[0]) + " is the next day");
                }
                Console.ReadKey();
