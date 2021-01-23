    namespace Business.Apartment.HR
    {
        public class Class1
        {
        }
    }
    namespace Apartment.HR.Area
    {
        public class Class2
        {
        }
    }
    namespace Business.Apartment
    {
        public class Caller
        {
            public Caller()
            {
                var c1 = new HR.Class1();
                var c2 = new Apartment.HR.Area.Class2();
            }
        }
    }
