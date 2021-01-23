        public class Slot
        {
            public DateTime Date;
            public TimeSpan StartHour;
            public TimeSpan EndHour;
            public string ShiftCode;
        }
        public List<Slot> GetSlots()
        {
            //Shifts Array
            Slot[] shifts = new Slot[4];
            shifts[0] = new Slot();
            shifts[0].StartHour = new TimeSpan(06, 00, 00);
            shifts[0].EndHour = new TimeSpan(12, 00, 00);   
            shifts[0].ShiftCode = "01";
            shifts[1] = new Slot();
            shifts[1].StartHour = new TimeSpan(12, 00, 00);
            shifts[1].EndHour = new TimeSpan(18, 00, 00);
            shifts[1].ShiftCode = "02";
            shifts[2] = new Slot();
            shifts[2].StartHour = new TimeSpan(18, 00, 00);
            shifts[2].EndHour = new TimeSpan(24, 00, 00);
            shifts[2].ShiftCode = "03";
            shifts[3] = new Slot();
            shifts[3].StartHour = new TimeSpan(00, 00, 00);
            shifts[3].EndHour = new TimeSpan(06, 00, 00);
            shifts[3].ShiftCode = "04";
            
            //Event TimeStamps
            DateTime startEvent = new DateTime(2015, 09, 01, 02, 00, 00);
            DateTime endEvent = new DateTime(2015, 09, 03, 08, 00, 00);
            if (endEvent < startEvent)
                return null;
            int i = 0;
            //To find the starting shift for the event
            while (!(
                    shifts[i].StartHour <= shifts[i].EndHour
                        ? (startEvent.TimeOfDay >= shifts[i].StartHour && startEvent.TimeOfDay < shifts[i].EndHour)
                        : (startEvent.TimeOfDay >= shifts[i].StartHour || startEvent.TimeOfDay < shifts[i].EndHour)
                    ))
                i++;
            //to establish the date part of the datetime according to the starttime of the shift day
            startEvent = startEvent.AddTicks(-shifts[0].StartHour.Ticks).Date + startEvent.TimeOfDay;
            endEvent = endEvent.AddTicks(-shifts[0].StartHour.Ticks).Date + endEvent.TimeOfDay;
            DateTime slotStart = startEvent;
            DateTime slotEnd = slotStart.Date + shifts[i].EndHour;
            List<Slot> slotList = new List<Slot>();
            while (endEvent.Date > slotEnd.Date || (endEvent.Date == slotEnd.Date && !(
                    shifts[i].StartHour <= shifts[i].EndHour
                        ? (endEvent.TimeOfDay >= shifts[i].StartHour && endEvent.TimeOfDay < shifts[i].EndHour)
                        : (endEvent.TimeOfDay >= shifts[i].StartHour || endEvent.TimeOfDay < shifts[i].EndHour)
                   )))
            {
                Slot newSlot = new Slot();
                newSlot.Date = slotStart.Date;
                newSlot.StartHour = slotStart.TimeOfDay;
                newSlot.EndHour = shifts[i].EndHour;
                newSlot.ShiftCode = shifts[i].ShiftCode;
                slotList.Add(newSlot);
                i++;
                if (i >= shifts.Length)
                {
                    i = 0;
                    slotStart = slotStart.Date.AddDays(1);
                }
                slotEnd = slotStart.Date + shifts[i].EndHour;
                slotStart = slotStart.Date + shifts[i].StartHour;
            }
            Slot lastSlot = new Slot();
            lastSlot.Date = slotStart;
            lastSlot.StartHour = slotStart.TimeOfDay;
            lastSlot.EndHour = endEvent.TimeOfDay;
            lastSlot.ShiftCode = shifts[i].ShiftCode;
            slotList.Add(lastSlot);
            return slotList;
        }
