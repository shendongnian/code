    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CodeFirstContext())
            {
                Console.Write("Enter a name: ");
                var name = Console.ReadLine();
                var cont = new Contact { ContactName = name };
                db.Contacts.Add(cont);
                db.SaveChanges();
                var usr = new User { UserName = "MyUsername", Contact = cont };
                db.Users.Add(usr);
                db.SaveChanges();
                var query = from b in db.Contacts
                            orderby b.ContactName
                            select b;
                Console.WriteLine("All contacts in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.ContactName);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
