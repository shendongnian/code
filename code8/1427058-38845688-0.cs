        abstract class parent
        {
            public abstract void printFirstName();
            internal virtual void printLastName()
            {
                Console.WriteLine("Watson");
            }
            public void printMiddlename()
            {
                Console.WriteLine("Jane");
            }
        }
       class child : parent
        {
            public override void printFirstName()
            {
                Console.WriteLine("Mary");
            }
            protected override void printLastName()
            {
                Console.WriteLine("Parker");
            }
            public void getMiddleName()
            {
                printMiddlename();
            }
        }
       class Program : child
        {
            static void Main(string[] args)
            {
                child ch = new child();
                ch.printFirstName();
                ch.getMiddleName();
                ch.printLastName();
                Console.Read();
            }
        }
    }
