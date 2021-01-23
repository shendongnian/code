    public partial class QnsNew1
    {
        public string Day
        {
            get
            {
                if (Date.HasValue)
                    return DateTime.Now.DayOfWeek.ToString();
                else
                    return null;
            }
        }
    }
