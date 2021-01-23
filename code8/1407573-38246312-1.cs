    public class Ellipse
    {
        public double x { get; set; }
        public double y { get; set; }
        public double a { get; set; }
        public double b { get; set; }        
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {            
            var el1 = new Ellipse { x = 10, y = 4, a = 5, b = 2 };
            var el2 = new Ellipse { x = 9, y = 4, a = 2, b = 3 };
    
            var Xmin = Math.Max(el1.x - el1.a, el2.x - el2.a);
            var Xmax = Math.Min(el1.x + el1.a, el2.x + el2.a);
    
            var step = 0.01;
            var accuracy = 0.01;
    
            Func<Ellipse, double, List<double>> calculateY = (el, x) => {
                var shift = el.b * Math.Sqrt(1 - Math.Pow((x - el.x) / el.a, 2));
                return new List<double> { el.y - shift, el.y + shift };
            };
    
            var result = new List<List<double>>();
            
            for(double i = Xmin; i <= Xmax; i += step)
            {
                var left = calculateY(el1, i);
                var right = calculateY(el2, i);
    
                for(var j = 0; j < 2; j++)                
                    if(Math.Abs(left[j] - right[j]) < accuracy)
                        result.Add(new List<double> { i, (left[j] + right[j]) / 2 });                                
            }
    
            foreach(var res in result)            
                Console.WriteLine(string.Format("x = {0}, y = {1}", res.First(), res.Last()));            
        }        
    }
