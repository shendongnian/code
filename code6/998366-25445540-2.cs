        int iteration = 0;
            while (iteration < durationDays)
            {
                while (expectedEndDate.DayOfWeek != DayOfWeek.Saturday && expectedEndDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    expectedEndDate = expectedEndDate.AddDays(1);
                    iteration++;
                    if (iteration == durationDays) break;
                }
                if (iteration == durationDays) break;
                if (expectedEndDate.DayOfWeek == DayOfWeek.Saturday) expectedEndDate=expectedEndDate.AddDays(2);
                if (expectedEndDate.DayOfWeek == DayOfWeek.Sunday) expectedEndDate=expectedEndDate.AddDays(1);
            }
            if (expectedEndDate.DayOfWeek == DayOfWeek.Saturday)expectedEndDate= expectedEndDate.AddDays(2);
            if (expectedEndDate.DayOfWeek == DayOfWeek.Sunday) expectedEndDate=expectedEndDate.AddDays(1);
