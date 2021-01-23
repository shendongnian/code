            var startDate = DateTime.Now;
            var durationDays = 2;
            var expectedEndDate = startDate.AddDays(durationDays);
           
            if (((int)startDate.DayOfWeek + durationDays) % 7 == 0)
            {
                expectedEndDate = expectedEndDate.AddDays(1);
            }
            else
            {
                if (((int)startDate.DayOfWeek + durationDays) % 6 == 0)
                {
                    expectedEndDate = expectedEndDate.AddDays(2);
                }
            }
