            List<Entry> newList = new List<Entry>();
            //Now adding the new "headers" 
            for (int i = 0; i < entries.Count; i++)
            {
                DateTime dateOfAppointment = (DateTime)entries[i].DateTime;
                if (i > 0)
                {
                    if (dateOfAppointment.Date != entries[i - 1].DateTime.Date)//Rrevious has NOT same Date
                    {
                        newList.Add(new Entry() {DateTime = dateOfAppointment});
                    }
                }
                else
                {
                    newList.Add(new Entry() { DateTime = dateOfAppointment });
                }
               
                newList.Add(entries[i]);//Add Entry
            }
