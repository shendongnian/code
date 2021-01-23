    public static class Helper
    {
        public static void Print(this IEnumerable<Person> people)
        {
            foreach(Person p in people) 
               Console.WriteLine(string.Format("Name : {0}, Last Name : {1}, Age : {2}", p.Name, p.LastName, p.Age));
        }
    }
