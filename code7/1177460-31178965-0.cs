    class DatePrev
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public static bool NoOverlap(this DatePrev dateA, DatePrev dateB)
        {
            return !(dateA.ToDate < dateB.FromDate || dateA.FromDate > dateB.ToDate);
        }
    }
    (...)
            var newDate = new DatePrev(); //specify from and to
            if (dateList.All(d => DatePrev.NoOverlap(d, newDate)))
                dateList.Add(newDate);
