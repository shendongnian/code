    static public class MyExtensions
    {
        static public IEnumerable<double> GetPointAverages(this IEnumerable<double> points)
        {
            var e = points.GetEnumerator();
            var reading = e.MoveNext();
            while (reading)
            {
                var value = e.Current;
                reading = e.MoveNext();
                if (reading && e.Current - value < .5)
                {
                    value = (value + e.Current) / 2;
                    reading = e.MoveNext();
                }
                yield return value;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            var pointsArray = new[] { 2.1, 2.2, 2.6, 4, 4.2, 4.7, 4.8 };
            var averages = String.Join(", ", 
                pointsArray.GetPointAverages().Select(p => p.ToString())
                );
            Console.WriteLine("Result: {0}", averages);
            Console.WriteLine();
            var pointsList = new List<double>() { 8.8, 9.0 };
            averages = String.Join(", ", 
                pointsList.GetPointAverages().Select(p => p.ToString())
                );
            Console.WriteLine("Result: {0}", averages);
       }
    }   
-- 
    Result: 2.15, 2.6, 4.1, 4.75
    Result: 8.9
