    class Program
    {
        static void Main(string[] args)
        {
            RandomList show = new RandomList(50, 10);
            show.TotalSum();
            show.Sort();
        }
    }
    class RandomList
    {
        private static Random rand = new Random();
        private List<double> _list; // this field holds your list
        public RandomList(int length , int maxValuePerItem) // this is the constructor
        {
            _list = new List<double>(); 
            // populate list
            for (int i = 0; i < length; i++)
            {
                _list.Add(rand.Next(maxValuePerItem)); 
            }
        }
        public void TotalSum()
        {
            Console.WriteLine("Total sum: {0}", _list.Sum()); // {0} is required to specify the place to put _list.Sum() inside string.
            // without linq way
            // int sum = 0;
            // foreach(var i in _list) sum += i;
        }
        public void Sort()
        {
            _list.Sort();
            foreach (var d in _list) 
            {
                Console.Write(d + " , "); // you need to print this in the way you want.
            }
        }
    }
