    class Program
    {
        List<object> myList1 = new List<object>();
        List<object> myList2 = new List<object>();
        List<object> myList3 = new List<object>();
        List<object> myList4 = new List<object>();
        List<object> myList5 = new List<object>();
        List<object> myList6 = new List<object>();
    
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
    
            Console.ReadLine();
        }
    
        void Run()
        {
            for (int i = 1; i <= 6; i++)
            {
                FieldInfo field = this.GetType().GetField("myList" + i, BindingFlags.NonPublic | BindingFlags.Instance);
                if (field != null)
                {
                    List<object> value = field.GetValue(this) as List<object>;
    
                    if (value != null)
                    {
                         //You can use it here
                    }
                    else
                    {
                         //Wasn't found
                    }
                }
            }
        }
    }
