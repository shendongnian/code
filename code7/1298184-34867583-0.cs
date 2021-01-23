        static void Main(string[] args)
        {
            Employee employee1 = new Employee();
           
            Console.Write("Gender: ");
    
            String userInput = Console.ReadLine();
            if (char.TryParse(userInput, out employee1.gender))
                Console.WriteLine("Ok, you specified: " + employee1.gender);
            else 
                Console.WriteLine("Not valid character: " + userInput); 
    
            employee1.Print();
        }
    
        public class Employee {
            public char gender = '?';
    
            public void Print() {
                Console.WriteLine("Gender is = " + gender);
            }
        }
