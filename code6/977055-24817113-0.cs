        public static void  GetHoursAndOvertimeWorked(string startTimeString, string endTimeString, out string hoursWorked, out string overtimeWorked)
        {
            var startTime = DateTime.Parse(startTimeString);
            var endTime = DateTime.Parse(endTimeString);
            GetHoursAndOvertimeWorked(startTime, endTime, out hoursWorked, out overtimeWorked);
        }
        private static void GetHoursAndOvertimeWorked(DateTime startTime, DateTime endTime, out string hoursWorked, out string overtimeWorked)
        {
            double diff2 = (endTime - startTime).TotalHours;
            hoursWorked = Convert.ToString(diff2) + "Hrs";
            var overtimeStartTime = startTime.Date.AddHours(22);
            if (endTime > overtimeStartTime)
            {
                double diff = (endTime - overtimeStartTime).TotalHours;
                overtimeWorked = Convert.ToString(diff) + "Hrs";
            }
            else
            {
                overtimeWorked = "0";
            }
        }
