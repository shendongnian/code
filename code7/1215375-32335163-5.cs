    public class Program
    {
        public static void Main(string[] args)
        {
            //Create the person
            Person p = new Person() { Name = "Joe Smith", Age = 142 };
            p.HappyBirthday += HappyBirthday;  //Subscribe to the event
            p.ItsMyBirthday(); //Raises the event
            Console.WriteLine("Press any key to quit");
            Console.ReadKey(true);
        }
        static void HappyBirthday(object sender, BirthdayEventArgs e)
        {
            //sender is the Person, and it has event arguments
            Console.WriteLine(e.Message);
        }
    }
