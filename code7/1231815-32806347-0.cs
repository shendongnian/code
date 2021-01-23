    public class ScheduleList : List<Schedule>
    {
        private BitArray ba = new BitArray(1440);
        // Define own Add method to Add a Schedule to the list
        // Or override the predefined one....
        public Schedule Add(int sh, int sm, int eh, int em)
        {
            Schedule s = new Schedule();
            s.StartTime = new DateTime(1, 1, 1, sh, sm, 0);
            s.EndTime = new DateTime(1, 1, 1, eh, em, 0);
            // Of course, having full control on the Add phase, you
            // could easily enforce your policy at this point. 
            // You could not accept a new schedule if the time slot is busy
            // but we could ignore it at this point
            this.Add(s);
            return s;
        }
    
        public bool IsTimeSlotBusy(Schedule s)
        {
            int sidx = Convert.ToInt32(TimeSpan.FromMinutes((s.StartTime.Hour * 60) + s.StartTime.Minute).TotalMinutes);
            int eidx = Convert.ToInt32(TimeSpan.FromMinutes((s.EndTime.Hour * 60) + s.EndTime.Minute).TotalMinutes);
            for (int x = sidx; x <= eidx; x++)
            {
                if (ba.Get(x)) return true;
                ba.Set(x, true);
            }
            return false;
        }
    }
