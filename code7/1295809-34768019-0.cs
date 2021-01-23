    // Your derived class
    public class WeekdayCounter : DayCounter
    {
        public override string Name() { return "Weekday" }
        public override double YearFraction(DateTime d1, DateTime d2) { return 0.0; }
        public override int DayCount(DateTime d1, DateTime d2) { return 0; }
    }
    // Create a FunBond
    WeekdayCounter c = new WeekdayCounter();  // **derived class**
    FunBond yay = new FunBond(id,
                              name,
                              currency,
                              notional,
                              maturityDate,
                              couponCashFlows,
                              c);   // **WeekdayCounter, which is a DayCounter**
