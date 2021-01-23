    if (MedRmndrDat.Valid)
    {
        foreach (var MedReminder in MedRmndrDat.Data)
        {
            if (Convert.ToBoolean(MedReminder.EveryDay))
            {
                if (DateTime.Now.Date >= MedReminder.MedicationIntakeStartDate.Date)
                {
                    **//it is not performing this if condition, it keeps jumping on next condition***                                  
                                            if (DateTime.Now == MedReminder.TimeSchedule1)
    
                    {
                        MessageSenderUtility.Sendsms(MobileNum, item.UserName, MedReminder.Description, MedReminder.MedicationName, MedReminder.Quantity.ToString());
                    }
    
                    else if (DateTime.Now.Date == MedReminder.TimeSchedule2.Date)
                    {
                        ... Some code ...
                    }
    
                    else if (DateTime.Now.Date == MedReminder.TimeSchedule3.Date)
                    {
                        ... Some code ...
                    }
                }
            }
        }
    }
