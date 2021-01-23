    class Program
    {
        static void Main(string[] args)
        {
            int currentPosition = 3;
            int expectedPosition = 7;
            int adjust = (currentPosition < expectedPosition) ? 1 : 0;
            List<int> list = new List<int> { 1,2,3,4,5,6,7,8,9,10};
            var item = list[currentPosition];
            list.RemoveAt(currentPosition);
            list.Insert(expectedPosition - adjust , item); //Insert position may be one less at the moment, so use calculated adjustment
            foreach (int i in list)
            {
                Console.WriteLine(i.ToString());
            }
            var discard = Console.ReadKey();
        }
    }
