            var startDate = DateTime.Now;
            var durationDays = 2;
            var expectedEndDate = startDate.AddDays(durationDays);
           
            if (expectedEndDate.DayOfWeek == DayOfWeek.Saturday)
            {
                expectedEndDate = expectedEndDate.AddDays(2);
            }
            else
            {
                if (expectedEndDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    expectedEndDate = expectedEndDate.AddDays(1);
                }
            }
