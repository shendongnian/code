    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                var user = from u in db.Users select u;
                foreach (var item in user)
                {
                    foreach (var item2 in item.usermeta)
                    {
                        Console.WriteLine(string.Format($"{item2.metakey}:{item2.value}"));
                    }
                }
            }
            Console.ReadKey();
        }
    }
