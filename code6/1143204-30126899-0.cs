    class Program
    {
        static void Main(string[] args)
        {
            MyList<string>.Add("something");
            MyList<string>.Add("something");
            MyList<string>.Add("something");
            Console.WriteLine(MyList<string>.countlist(MyList<string>.jdtlist));
            Console.ReadKey();
        }
    }
    public class MyList<AnyDataType>
    {
        public static List<AnyDataType> jdtlist = new List<AnyDataType>();
    
        public static void Add(AnyDataType item)
        {
            jdtList.Add(item);
        }
    
        public static int countlist(List<AnyDataType> list) 
        {
            int listcount = 0;
            for (int i = 0; i < list.Count; i++)
            {
                listcount++;
            }
            return listcount;
        }
