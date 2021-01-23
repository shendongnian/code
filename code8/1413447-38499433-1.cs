    //List<int> ListOfDays = new List<int>() { DaysToNumber(Days.Mon), DaysToNumber(Days.Tue) };
                //List<int> ListOfDays = new List<int>() { DaysToNumber(Days.Mon), DaysToNumber(Days.Wed) };
                //List<int> ListOfDays = new List<int>() { DaysToNumber(Days.Mon), DaysToNumber(Days.Tue), DaysToNumber(Days.Fri), DaysToNumber(Days.Sat) };
                //List<int> ListOfDays = new List<int>() { DaysToNumber(Days.Mon), DaysToNumber(Days.Wed), DaysToNumber(Days.Fri), DaysToNumber(Days.Sun) };
                //List<int> ListOfDays = new List<int>() { DaysToNumber(Days.Mon), DaysToNumber(Days.Tue), DaysToNumber(Days.Wed), DaysToNumber(Days.Thur), DaysToNumber(Days.Fri), DaysToNumber(Days.Sat), DaysToNumber(Days.Sun) };
                List<int> ListOfDays = new List<int>() { DaysToNumber(Days.Mon),DaysToNumber(Days.Fri),  DaysToNumber(Days.Sun) };
                var ListToIterate = ListOfDays.Distinct().OrderBy(d => d).ToList();
                var result = GroupDay(ListToIterate);
