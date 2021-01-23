     public Dictionary<int, int> GetHrsInDay()
            {
                Dictionary<int, int> hrsInDay = new Dictionary<int, int>();
    
                for (int i = 1; i < 25; i++)
                {
                    hrsInDay.Add(i, i);
                }
                return hrsInDay;
            }
