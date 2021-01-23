    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
        static void Main(string[] args)
        {
            var survey1 = new Survey() { Topic = "topic1", Store1Rate = 5, Store2Rate = 4 };
            var survey2 = new Survey { Topic = "topic2", Store1Rate = 6, Store2Rate = 2 };
            var survey3 = new Survey { Topic = "topic2", Store1Rate = 7, Store2Rate = 2 };
            var survey4 = new Survey { Topic = "topic3", Store1Rate = 6, Store2Rate = 4 };
            var survey5 = new Survey { Topic = "topic3", Store1Rate = 1, Store2Rate = 2 };
            var survey6 = new Survey { Topic = "topic3", Store1Rate = 2, Store2Rate = 9 };
            List<Survey> surveys = new List<Survey>() { survey1, survey2, survey3, survey4, survey5, survey6 };
            var result = surveys.GroupBy(s => s.Topic).Select(s => new { Topic = s.Key, Rate1 = s.Average(a => a.Store1Rate), Rate2 = s.Average(a => a.Store2Rate) });
        }
    }
    class Survey
    {
        public string Topic;
        public int Store1Rate;
        public int Store2Rate;
    }
}
