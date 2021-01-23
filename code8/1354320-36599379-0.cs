    namespace ConsoleApplication
    {
        public class Dominoe
        {
            public Dominoe(int left, int right)
            {
                LeftSide = left;
                RightSide = right;
            }
    
            public int LeftSide;
            public int RightSide;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var input = new List<Dominoe>()
                {
                    new Dominoe(2, 3), 
                    new Dominoe(1, 2), 
                    new Dominoe(4, 5), 
                    new Dominoe(3, 4)
                };
    
                var dicLeft = new Dictionary<int, Dominoe>();
                var dicRigth = new Dictionary<int, Dominoe>();
    
                foreach (var item in input)
                {
                    dicLeft.Add(item.LeftSide, item);
                    dicRigth.Add(item.RightSide, item);
                }
    
                Dominoe first = null;
    
                foreach(var item in input)
                {
                    if (!dicRigth.ContainsKey(item.LeftSide))
                    {
                        first = item;
                        break;
                    }
                }
    
                Console.WriteLine(string.Format("{0} - {1}", first.LeftSide, first.RightSide));
    
                for(int i = 0; i < input.Count - 1; i++)
                {
                    first = dicLeft[first.RightSide];
                    Console.WriteLine(string.Format("{0} - {1}", first.LeftSide, first.RightSide));
                }
    
                Console.ReadLine();
            }
        }
    }
