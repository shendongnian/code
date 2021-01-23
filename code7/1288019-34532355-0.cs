    DateTime testTime = DateTime.Now;
    testTime = testTime.AddSeconds(-testTime.Second).AddMilliseconds(-testTime.Millisecond);
    if (testTime >= MedReminder.MedicationIntakeStartDate)
    {
        if (testTime == MedReminder.TimeSchedule1) 
        {
            ... some code
        }
        else if (testTime == MedReminder.TimeSchedule2)
        {
           ... Some code ...
        }
        else if (testTime == MedReminder.TimeSchedule3)
        {
               ... Some code ...
        }
