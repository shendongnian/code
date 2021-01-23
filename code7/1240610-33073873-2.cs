    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Contact c1 = new Contact();
                c1.FirstNames.ForEach(Console.WriteLine);
                Console.ReadLine();
            }
        }
    
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
    
            public List<string> FirstNames { get; set; }
    
            public Contact()
            {
                List<Contact> _contactList = new List<Contact>();
                _contactList.Add(new Contact("selva", "rani", 45));
                _contactList.Add(new Contact("sandhu", "dhya", 20));
                _contactList.Add(new Contact("sasi", "kala", 19));
                _contactList.Add(new Contact("s2", "s3", 44));
                FirstNames = _contactList.Select(C => C.FirstName).ToList<string>();
            }
        }
    }
