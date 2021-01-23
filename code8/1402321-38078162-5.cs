            List<newClass> output = acts.Select((a, index) => new newClass()
            {
                Name = a.Name,
                AdditionalData = a.AdditionalData,
                StartTime = a.ActivityTime,
                EndTime = (index + 1 < acts.Count) ? acts[index + 1].ActivityTime : default(DateTime)
            }).ToList();
