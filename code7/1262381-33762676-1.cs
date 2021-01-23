    using System.Linq;
    
    namespace BatchLinq
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var myList = Enumerable.Range(0, 23);
                var groups = myList.Select((x,i) => new {X=x, I=i/5})
                           .GroupBy(xi => xi.I, xi => xi.X);
    
                foreach (var group in groups)
                    System.Console.Out.WriteLine("{{ {0} }}", string.Join(", ", group));
            }
        }
    }
