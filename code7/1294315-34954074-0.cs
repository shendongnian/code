    class User { public string FullName { private get; set; } }
……………
    static void Main(string[] args)
            {     User u = new User();
                u.FullName = "Banketeshvar Narayan";
                Console.WriteLine(u.FullName);            
            }
