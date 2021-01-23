      private void CalculateTotalHour(string dtstartTime, string dtendTime)
        {
             
                DateTime d1 = new DateTime();
                d1 = Convert.ToDateTime(dtstartTime); DateTime d2 = new DateTime();
                d2 = Convert.ToDateTime(dtendTime);
                if (d1.Hour >= 12)
                {
                    d1 = d1.AddDays(-1);
                }
                else if (d2.Hour >= 12)
                {
                    d2 = d2.AddDays(1);
                }
              //  if (d2 < d1)
               //  MessageBox.Show("shift end time is lesser than shift start time", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 TimeSpan ts = d2.Subtract(d1).Duration();
               // ts.ToString(@"hh\:mm")//total dur
        }
