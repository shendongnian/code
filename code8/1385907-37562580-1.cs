     class Program
        {
            static void Main(string[] args)
            {
                List <Person> P_list = new List<Person>();
                P_list.Add(new Person("Jack", "Harvey", "Smyrna, GA 30080"));
                P_list.Add(new Person("Tyler", "Marsden", "Iowa City, IA 52240"));
                P_list.Add(new Person("Callum", "Richardson ", "Marquette, MI 49855"));
                P_list.Add(new Person("Taylor", "Craig ", "Logan, UT 84321"));
                P_list.Add(new Person("Callum", "Richardson ", "Marquette, MI 49855"));
                P_list.Add(new Person("Tyler", "Marsden", "Iowa City, IA 52240"));
                P_list.Add(new Person("William", "Donnelly", "Richmond, IN 47374"));
                P_list.Add(new Person("Callum", "Richardson ", "Marquette, MI 49855"));
                P_list.Add(new Person("Jack", "Harvey", "Smyrna, GA 30080"));
                P_list.Add(new Person("Billy", "Reid ", "New York, NY 10029"));            
    
                IEnumerable<Person> distinct = P_list.Distinct(new PersonComparer());
                foreach (var item in distinct)
                {
                    Console.WriteLine("{0} {1} {2}", item.FName,item.LName,item.Location);
                }
                Console.Read();
            }
    
        }
    
        class Person
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public string Location { get; set; }
            public Person(string f, string l, string loc)
            {
                FName = f;
                LName = l;
                Location = loc;
            }
        }
    
        public class PersonComparer : IEqualityComparer<Person>
        {
            bool IEqualityComparer<Person>.Equals(Person x, Person y)
            {
                return (x.FName == y.FName & x.LName == y.LName && x.Location == y.Location);
            }
    
            int IEqualityComparer<Person>.GetHashCode(Person obj)
            {
                string person = string.Format("{0} {1} {2}", obj.FName, obj.LName, obj.Location);
                return person.GetHashCode();
            }
        }
