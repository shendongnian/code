            List<Entry> newList = new List<Entry>();
            //Now adding the new "headers" 
            for (int i = 0; i < entries.Count; i++)
            {
                DateTime dateOfAppointment = (DateTime)entries[i].DateTime;
                if (i > 0)
                {
                    if (dateOfAppointment.Date != entries[i - 1].DateTime.Date)//Not the same Date as the previous one => Add new Header with Date
                    {
                        newList.Add(new Entry() {DateTime = dateOfAppointment});
                    }
                }                
                //Else: we add the entry under the current date cause its still the same...
                newList.Add(entries[i]);//Add Entry
            }
