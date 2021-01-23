    class Person
    {
        public string name;
        public string alias;
        public Person(string _name, string _alias = "")
        {
            name = _name;
            alias = _alias;
        }
    }
    
    class House
    {
        public string name;
        public string id;
        public string alias;
        public List<Person> people = new List<Person>();
        public House(string _name, string _id, string _alias = "")
        {
            name = _name;
            id = _id;
            alias = _alias;
        }
    }
    class Program
    {
        static List<House> houses = new List<House>();
        static void Main(string[] args)
        {
            // Add houses here
            foreach (House house in FindHouses("criteria"))
            {
                // Do stuff
            }
        }
        // Find all the houses in which the criteria exists
        static List<House> FindHouses(string criteria)
        {
            // Return the list of all houses in which the criteria exists
            return houses.Where(h =>
                h.name.Contains(criteria) ||
                h.id == criteria ||
                h.alias.Contains(criteria) ||
                
                h.people.Any(p => 
                p.name.Contains(criteria) ||
                p.alias.Contains(criteria))).ToList();
        }
    }
