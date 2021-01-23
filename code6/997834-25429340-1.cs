    // ensure that it's sorted by date
    percentages.Sort((p1, p2) => p1.Date.CompareTo(p2.Date));
    List<Percentages> newPercentages = new List<Percentages>();
    for (int i = 0; i < percentages.Count; i++)
    {
        Percentages percentage = percentages[i];
        Percentages lastPercentage = newPercentages.LastOrDefault();
        if (lastPercentage != null)
        {
            TimeSpan diff = percentage.Date - lastPercentage.Date;
            int missingMinutes = (int)diff.TotalMinutes - 1;
            if(missingMinutes > 0)
            {
              var missing = Enumerable.Range(1, missingMinutes)
                .Select(n => new Percentages
                {
                    Date = lastPercentage.Date.AddMinutes(n),
                    Average = lastPercentage.Average,
                    High = lastPercentage.High,
                    Low = lastPercentage.Low
                });
              newPercentages.AddRange(missing);
            }
        }
        newPercentages.Add(percentage);
    } 
