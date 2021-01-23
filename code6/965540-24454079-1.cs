        DateTime startTime = DateTime.Now;
        List<dynamic> events = new List<dynamic>();
        for (int i = 0; i < 3000; i++)
        {
            if (i % 2 == 0) //is even
            {
                var dataStart = new
                {
                    TimeId = startTime.AddSeconds(i),
                    ValueStart = i
                };
                events.Add(dataStart); // <-- 
             }
         }
