    using System;
    using System.Globalization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Prepare to write the date and time data.
                string FileName = string.Format(@"C:\users\public\documents\{0}.txt", Guid.NewGuid());
                StreamWriter sw = new StreamWriter(FileName);
                //Create a Persian calendar class
                PersianCalendar pc = new PersianCalendar();
                // Create a date using the Persian calendar.
                DateTime wantedDate = pc.ToDateTime(1395, 4, 22, 12, 30, 0, 0);
                sw.WriteLine("Gregorian Calendar:  {0:O} ", wantedDate);
                sw.WriteLine("Persian Calendar:    {0}, {1}/{2}/{3} {4}:{5}:{6}\n",
                              pc.GetDayOfWeek(wantedDate),
                              pc.GetMonth(wantedDate),
                              pc.GetDayOfMonth(wantedDate),
                              pc.GetYear(wantedDate),
                              pc.GetHour(wantedDate),
                              pc.GetMinute(wantedDate),
                              pc.GetSecond(wantedDate));
                sw.Close();
            }
        }
    }
