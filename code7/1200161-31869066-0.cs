    public class Program
    {
        static bool hasFormatted = false;
        public void Main(string[] args)
        {
            formatDate();
        }
        public string formatDate(DateTime? myDate = null)
        {
            string formateddDate;
            //replace the null
            if (!myDate.HasValue)
            {
                myDate = DateTime.Now;
            }
            //if (myDate == null) 
            //  myDate = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day);
            if (hasFormatted == true)
            {
                return "The date " + myDate + " is already formatted.";
            }
            else
            {
                formateddDate= String.Format("{0:y yy yyy yyyy}", myDate);
            }
            return formateddDate;
        }
    }
