    class Program
    {
        static void Main(string[] args)
        {
            List<object>[] myList = new List<object>[4];
            AClass aClass = new AClass();
            BClass bClass = new BClass();
            myList[0] = new List<object>() { "a", "b", "c", "d" };
            myList[1] = new List<object>() { "0", "1", "2", "3", "4" };
            myList[2] = new List<object>() { 0, 1, 2 };
            myList[3] = new List<object>() { aClass, bClass };
            List<List<object>> result = CombineListOfCollections(myList);
            PrintList(result);
        }
        static List<List<object>> CombineListOfCollections(List<object>[] myList)
        {
            List<List<object>> result = myList[0].Select(element => new List<object>() { element }).ToList();
            for (int i = 1; i < myList.Length; i++)
            {
                result = CombineCollections(result, myList[i]).ToList();
            }
            return result;
        }
        private static IEnumerable<List<object>> CombineCollections(IEnumerable<List<object>> collection1, List<object> collection2)
        {
            return from c1 in collection1 from c2 in collection2 select new List<object>(c1) { c2 };
        }
        // A more verbose form of CombineCollections that may be easier to understand:
        //private static IEnumerable<List<object>> CombineCollections(IEnumerable<List<object>> collection1, List<object> collection2)
        //{
        //    foreach (List<object> c1 in collection1)
        //    {
        //        foreach (object c2 in collection2)
        //        {
        //            List<object> l1 = new List<object>(c1) { c2 };
        //            yield return l1;
        //        }
        //    }
        //}
        private static void PrintList(List<List<object>> collection)
        {
            collection.ForEach(list =>
            {
                list.ForEach(element =>
                {
                    Console.Write(element);
                    Console.Write(" ");
                });
                Console.WriteLine();
            });
        }
    }
    public class AClass
    { }
    public class BClass
    { }
