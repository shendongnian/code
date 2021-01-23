    using System;
    using System.Globalization;
    using NodaTime;
    using NodaTime.Text;
    
    public class Test
    {
        public static void Main()        
        {
            // Providing the sample date to the pattern tells it which
            // calendar to use.
            // Noda Time 2.0 uses a property instead of a method.
            // var calendar = CalendarSystem.Persian;           // 2.0+
            var calendar = CalendarSystem.GetPersianCalendar(); // 1.x
            LocalDate sampleDate = new LocalDate(1392, 10, 12, calendar);
            var pattern = LocalDatePattern.Create(
                "yyyy/M/d", CultureInfo.InvariantCulture, sampleDate);
            string text = "1393/04/31";
            ParseResult<LocalDate> parseResult = pattern.Parse(text);
            if (parseResult.Success)
            {
                LocalDate date = parseResult.Value;
                // Use the date
            }
        }    
    }
