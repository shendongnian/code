    namespace List
    {
        class Program
        {
            //Create a dictionary to find out each question is realated to which property.
            private static Dictionary<string, string> questions = new Dictionary<string, string>();
            static void Main()
            {
                questions.Add("Enter  name", "Name");
                questions.Add("enter phone number", "Phone");
                questions.Add("enter 2 didigt month dob", "Month");
                questions.Add("enter 2 digit day dob", "Day");
                questions.Add("enter 2 digit dob year", "Year");
                //Create list of friends
                List<Friends> friendsList = new List<Friends>();
                for (int x = 0; x <= 8; x++)
                {
                    Friends f = new Friends();
                    foreach (string q in questions.Keys)
                    {
                        Console.WriteLine("{0}", q);
                        //Find property using Sytem.Reflection
                        System.Reflection.PropertyInfo property = f.GetType().GetProperty(questions[q]);
                        //Set value of found property
                        property.SetValue(f, Convert.ChangeType(Console.ReadLine(), property.PropertyType), null);
                    }
                    //Add a friend to list
                    friendsList.Add(f);
                }
            }
        }
    }
    
    public class Friends
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
