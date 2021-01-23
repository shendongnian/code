     for (DateTime tm = time.AddHours(8); tm < time.AddHours(22); tm = tm.AddMinutes(30))
                {
                    cmbBoxStart.Items.Add(tm.ToShortTimeString());
    
                }
