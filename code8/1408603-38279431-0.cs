    //Since i dont know what Staff_Time_TBL has or represents, i will use this as example
    public class SomeClass
    {
        public int number;
        public string text;
        public bool flag;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Your observable collection
            ObservableCollection<SomeClass> observableSomeClass = new ObservableCollection<SomeClass>();
            //I am assuming that in your LINQ query you are using a list or a structure, this is not important at all
            List<SomeClass> listSomeClass = new List<SomeClass>();
            //Im just adding some data to my list to work with
            listSomeClass.Add(new SomeClass
            {
                number = 1,
                text = "ONE",
                flag =  true
            });
            listSomeClass.Add(new SomeClass
            {
                number = 2,
                text = "TWO",
                flag = false
            });
            listSomeClass.Add(new SomeClass
            {
                number = 3,
                text = "THREE",
                flag = true
            });
            //This is a example LINQ query which is going to return me the ones that flag is equals to true (2)
            var result = from node in listSomeClass
                         where node.flag == true
                         select new
                         {
                             node.number,
                             node.text,
                             node.flag
                         };
            //THIS IS THE TRICK:
            //Instead of trying making a convertion or a toList(), try iterating your result from your linq query and adding it to your observable structure
            foreach (var r in result)
            {
                observableSomeClass.Add(new SomeClass
                {
                    number = r.number,
                    text = r.text,
                    flag = r.flag
                }
                );
                
            }
            Console.ReadLine();
        }
