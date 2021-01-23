    namespace List
    {
        class Program
        {
            private static Dictionary<string, string> questions = new Dictionary<string, string>();
            static void Main()
            {
                questions.Add("Enter  name", "Name");
                questions.Add("enter phone number", "Phone");
                questions.Add("enter 2 didigt month dob", "Month");
                questions.Add("enter 2 digit day dob", "Day");
                questions.Add("enter 2 digit dob year", "Year");
                for (int x = 0; x <= 8; x++)
                {
                    Friends f = new Friends();
                    foreach (string q in questions.Keys)
                    {
                        Console.WriteLine("{0}", q);
                        System.Reflection.PropertyInfo property = f.GetType().GetProperty(questions[q]);
                        property.SetValue(f, Convert.ChangeType(Console.ReadLine(), property.PropertyType), null);
                    }
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
