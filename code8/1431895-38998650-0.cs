    class Program
    {
        static void Main(string[] args)
        {
            List<A> aList = new List<A> {new A {OtherAData = "First A", SomeDateTime = DateTime.Parse("12-11-1980")},
                                         new A {OtherAData = "Second A", SomeDateTime = DateTime.Parse("12-11-2000")} };
            List<B> bList = new List<B> {new B {OtherBData = "First B", SomeOtherDateTime = DateTime.Parse("12-11-1990")}, 
                                         new B {OtherBData = "Second B", SomeOtherDateTime = DateTime.Parse("12-11-2010")} };
            // create projections
            var unionableA = from a in aList
                select new {SortDateTime = a.SomeDateTime, AValue = a, BValue = (B) null};
            var unionableB = from b in bList
                select new {SortDateTime = b.SomeOtherDateTime, AValue = (A) null, BValue = b};
            // union the two projections and sort
            var union = (from a in unionableA select a)
                           .Union(from b in unionableB select b)
                           .OrderBy(u => u.SortDateTime);
            foreach (var u in union)
            {
                if (u.AValue != null)
                {
                    Console.WriteLine("A: {0}",u.AValue);
                }
                else if (u.BValue != null)
                {
                    Console.WriteLine("B: {0}",u.BValue);
                }
            }
        }
    }
    public class A
    {
        public DateTime SomeDateTime { get; set; }
        public string OtherAData { get; set; }
        public override string ToString()
        {
            return string.Format("SomeDateTime: {0}, OtherAData: {1}", SomeDateTime, OtherAData);
        }
    }
    public class B
    {
        public DateTime SomeOtherDateTime { get; set; }
        public string OtherBData { get; set; }
        public override string ToString()
        {
            return string.Format("SomeOtherDateTime: {0}, OtherBData: {1}", SomeOtherDateTime, OtherBData);
        }
    }
