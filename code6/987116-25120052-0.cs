    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int numberOfLoops = 10;
            List<List<int>> myFullList = new List<List<int>>();
            for (int i = 0; i < numberOfLoops; i++)
            {
                List<int> myInnerList = new List<int>();
                for (int j = 0; j < 10; j++)
                {
                    // Populate inner list with random numbers
                    myInnerList.Add(rnd.Next(0, 10));
                }
                // Add the inner list to the full list
                myFullList.Add(myInnerList);
            }
            myFullList = Transpose<int>(myFullList);
            List<int> result = new List<int>();
            foreach (List<int> subList in myFullList)
                result.Add(Mode(subList));
            //TO-DO: linq version!
            //List<int> result = myFullList.ForEach(num => Mode(num));
            
        }
        public static int Mode(List<int> x)
        {
            int mode = x.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
            return mode;
        }
        public static List<List<T>> Transpose<T>(List<List<T>> lists)
        {
            var longest = lists.Any() ? lists.Max(l => l.Count) : 0;
            List<List<T>> outer = new List<List<T>>(longest);
            for (int i = 0; i < longest; i++)
                outer.Add(new List<T>(lists.Count));
            for (int j = 0; j < lists.Count; j++)
                for (int i = 0; i < longest; i++)
                    outer[i].Add(lists[j].Count > i ? lists[j][i] : default(T));
            return outer;
        }
    }
