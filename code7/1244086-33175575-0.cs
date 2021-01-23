    static void Main(string[] args)
            {
                List<User> usersList = new List<User>();
                string[] lines = System.IO.File.ReadAllLines("users.txt");
                foreach ( var line in lines)
                {
                    User user = new User();
                    user.user = line.Split(' ')[0];
                    user.password = line.Split(' ')[1];
                    usersList.Add(user);
                }
                foreach (var item in usersList)
                {
                    Console.WriteLine(item.user);
                    Console.WriteLine(item.password);
                }
                Console.ReadLine();
            }
    
            
    }
    public class User
    {
       public string user { get; set; }
       public  string password { get; set; }
    }
