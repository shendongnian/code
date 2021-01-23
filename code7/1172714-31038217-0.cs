    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < days.Length; index++)
            {
                // Yield each day of the week. 
                yield return days[index];
            }
        }
    }
