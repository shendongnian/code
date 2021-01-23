    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> myRangedDic = new Dictionary<int,int>();
            Range.CreateRange(10, 20);
            Range.CreateRange(50, 100);
            myRangedDic.Add(new Range(15).value, 1000);
            myRangedDic.Add(new Range(75).value, 5000);
            Console.WriteLine("searching for 16 : {0}", myRangedDic[new Range(16).value].ToString());
            Console.WriteLine("searching for 64 : {0}", myRangedDic[new Range(64).value].ToString());
            Console.ReadLine();
        }
    }
