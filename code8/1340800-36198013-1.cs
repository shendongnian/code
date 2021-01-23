        DateTime current = new DateTime(
            currentTime.Year, currentTime.Month, currentTime.Day, 
            currenTime.Hour, currentTime.Minute, currentTime.Second, currentTime.Kind).
            AddMilliseconds(currentTime.Millisecond);
        var availableValues = from value in AvailableValues
            where currentTime == new DateTime(
                value.Time.Year, value.Time.Month, value.Time.Day, 
                value.Time.Hour, value.Time.Minute, value.Time.Second, value.Time.Kind).
                AddMilliseconds(value.Time.Millisecond)
            select value;
