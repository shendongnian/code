    public class Class1
        {
            Random rand = new Random();
            List<double> alist { get; set; }
            public Class1(int howmany = 50)
            {
                alist = new List<double>();
                for (var i = 0; i < howmany; i++)
                {
                    alist.Add(rand.NextDouble());
                }
            }
            public void Sort()
            {
                alist.Sort();
            }
            public void printTotalSum()
            {
                Console.WriteLine("Total sum: {0}", alist.Sum());
            }
            public void printList() {
                Console.WriteLine("The list contains:");
                for (int i = 0; i < alist.Count; i++)
                {
                    Console.WriteLine(alist[i]);
                }
            }
        }
       class Program
        {
            static void Main(string[] args)
            {
                Class1 show = new Class1(10);
                show.printTotalSum();
                show.Sort();
                show.printList();
            }
        }
