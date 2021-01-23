    if (MedRmndrDat.Valid)
    {
        var now = DateTime.Now;
        now = now.Date.AddHours(now.Hour).AddMinutes(now.Minute)
        foreach (var MedReminder in MedRmndrDat.Data)
        {
            if (Convert.ToBoolean(MedReminder.EveryDay))
            {
                if (DateTime.Now >= MedReminder.MedicationIntakeStartDate)
                {
                    if (now == MedReminder.TimeSchedule1) 
                    {
                        MessageSenderUtility.Sendsms(MobileNum, item.UserName, MedReminder.Description, MedReminder.MedicationName, MedReminder.Quantity.ToString());
                    }
    
                    else if (now == MedReminder.TimeSchedule2)
                    {
                       ... Some code ...
                    }
    
                    else if (now == MedReminder.TimeSchedule3)
                    {
                           ... Some code ...
                    }
                }
            }
        }
    }
