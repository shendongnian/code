      namespace TestCode
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var list = new List<TC> {new TC(2), new TC(2), new TC(3), new TC(4), new TC(5), new TC(2)};
        
                    var dt = list.Where( // Contains 3 elements
                        x => x.X == 2
                        );
        
                    //var ds = from set in list
                    //         from table in set
                    //         where li.Where(e => e.Tables.Contains("Group"))
                    //         select table;
                }
            }
        
            internal class TC
            {
                public int X { get; set; }
                internal TC(int val)
                {
                    X = val; 
                }
            }
        
        }
