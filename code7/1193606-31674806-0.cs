    public class Printer
    {
        public Printer() { }
        public void printAPerson(dynamic p)
        {
            //do stuff with p
            Console.WriteLine("Person name: " + p.name);
        }
        public void printATable(dynamic t)
        {
            // do stuff with t
            Console.WriteLine("printATable(Table p) is called");
        }
    }
    public class TestDynamic
    {
        public static void Test()
        {
            // To get the type by name, 
            // the full type name (namespace + type name) is needed
            Type personType = Type.GetType("StackOverflowCodes.Person");
            object personObj = Activator.CreateInstance(personType);
            // Implicit cast to dynamic
            dynamic person = personObj;
            person.SetName("Alan Turing");
            Type printerType = Type.GetType("StackOverflowCodes.Printer");
            object printerObj = Activator.CreateInstance(printerType);
            dynamic printer = printerObj;
            printer.printAPerson(personObj);
        }
    }
