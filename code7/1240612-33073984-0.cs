    namespace sealedclass
    {
        public class Contact
        {
            private string _firstName;
            private string _lastName;
            private int _age;
            public Contact(string fname, string lname, int age)
            {
                _firstName = fname;
                _lastName = lname;
                _age = age;
            }
            public string FirstName
            {
                get
                {
                    return _firstName;
                }
                set
                {
                    _firstName = value;
                }
            }
            public string LastName
            {
                get
                {
                    return _lastName;
                }
                set
                {
                    _lastName = value;
                }
            }
            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    _age = value;
                }
            }
        }
        class Program
        {
            public static List<string> FirstNames
            {
                get
                {
                    return _contactList.Select(C => C.FirstName).ToList(); // Note that this isn't the best use of properties. Because it is creating a new object, this should really be a method.
                }
            }
            private static List<Contact> _contactList = new List<Contact>();
            static void Main(string[] args)
            {
                _contactList.Add(new Contact("selva", "rani", 45));
                _contactList.Add(new Contact("sandhu", "dhya", 20));
                _contactList.Add(new Contact("sasi", "kala", 19));
                _contactList.Add(new Contact("s2", "s3", 44));
                //You can do whatever you want with Console.WriteLine() here
            }
        }
    }
