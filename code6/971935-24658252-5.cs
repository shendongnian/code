    class Discount
    {
        public int DiscountID { get; set; } //You will need some Key field if you are storing these in a database.
        public DateTime issueDate { get; set; }
        public DateTime expirationDate { get; set; }
        public List<PeriodInterval> intervals { get; set; }
        public Discount(DateTime IssueDate, DateTime ExpirationDate)
        {
            issueDate = IssueDate;
            expirationDate = ExpirationDate;
            intervals = new List<PeriodInterval>();
        }
        public void AddInterval(DateTime StartDate, DateTime EndDate)
        {
            intervals.Add(new PeriodInterval() { 
                StartMonth=StartDate.Month,
                StartDay=StartDate.Day,
                EndMonth=EndDate.Month,
                EndDay=EndDate.Day
            });
        }
        public List<Period> GetPeriods()
        {
            List<Period> periods=new List<Period>();
            int yearCount = expirationDate.Year-issueDate.Year+1; //+1: Run at least one year against the periods.
            for (int i = 0; i < yearCount; i++)
            {
                //Loop through all the years and add 'Periods' from all the PeriodInterval info.
                foreach (PeriodInterval pi in intervals)
                {
                    var period = pi.GetPeriod(issueDate, expirationDate, i);
                    if (period != null)
                        periods.Add(period);
                }
            }
            return periods;
        }
    }
    class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    class PeriodInterval
    {
        public int PeriodIntervalID { get; set; } //You will need some Key field if you are storing these in a database.
        public int DiscountID { get; set; } //Foreign Key to Discount. This is alsof for database storage.
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }
        public Period GetPeriod(DateTime issueDate, DateTime expirationDate, int Year)
        {
            DateTime PeriodStart = new DateTime(issueDate.AddYears(Year).Year, StartMonth, StartDay);
            DateTime PeriodEnd = new DateTime(issueDate.AddYears(Year).Year, EndMonth, EndDay);
            PeriodStart=new DateTime(Math.Max(PeriodStart.Ticks, issueDate.Ticks)); //Limit period to the max of the two start dates.
            PeriodEnd = new DateTime(Math.Min(PeriodEnd.Ticks, expirationDate.Ticks)); //Limit period to the min of the two end dates.
            if(PeriodEnd>PeriodStart) //If a valid period
            {
                return new Period()
                {
                    StartDate = PeriodStart,
                    EndDate = PeriodEnd
                };
            }
            //Default Return Null
            return null;
        }
    }
