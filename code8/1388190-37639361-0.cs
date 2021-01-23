    public class DateVM
    {
        public DateVM() { } // default constructor required by the DefaultModelBinder
        public DateVM(DateTime date) // useful if your editing existing dates
        {
            Date date.Date;
            Day = date.Day;
            Month = date.Month;
            Year = date.Year;
        }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [Required(ErrorMessage = "The values for the date are not valid")]
        public DateTime Date { get; set; }
    }
