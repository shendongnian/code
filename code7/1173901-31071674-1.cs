    public class DateTimeNowAlertDatePopulator : IAlertDatePopulator {
         public DateTime Populate() { return DateTime.Now; }
    }
    public class SomeCalculationAlertDatePopulator : IAlertDatePopulator {
         public DateTime Populate() { return /* something calculated */; }
    }
