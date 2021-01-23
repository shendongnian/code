    public class HighlightHelper
    {
        public static bool IsHighlighted(object obj)
        {
            bool shouldHighlight = false;
            if(obj is DateTime)
            {
                var date = (DateTIme)obj;
                shouldHighlight = date != null && date.DayOfWeek == DayOfWeek.Thursday;
            }
            else if(obj is int)
            {
                var number = (int)obj;
                shouldHighlight = number % 2 == 0;
            }
            // et cetera...
            return shouldHighlight;   
        }
    }
