    abstract class Base
    {
        protected abstract void GetMinDate (ref DateTime minDate);
    }
    
    class Derived
    {
        private static readonly DateTime _MinDate;
        static Derived()
        {
           _MinDate = new DateTime(2005, 3, 25);
        }
        protected override void GetMinDate (ref DateTime minDate);
        {
            minDate = _MinDate;
        }
    }
