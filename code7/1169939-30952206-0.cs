        public class Person
        {
            string name;
            int age;
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public override string ToString()
            {
                string s = age.ToString();
                return "Person: " + name + " " + s;
            }
            // here
            public static implicit operator string(Person d)
            {
                return d.ToString();
            }
        }
        public class MyClass
        {
            public int Id { get; set; }
            public Person Person { get; set; }
        }
        static void Main(string[] args)
        {
            var myclass = new MyClass();
            myclass.Person = new Person("test", 12);
            // use like this
            string name = myclass.Person;
            Console.WriteLine(name);
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
