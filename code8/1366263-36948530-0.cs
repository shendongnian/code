    class Program {
        static void Main(string[] args) {            
            var person = new Person();
            var prop = person.GetType().GetProperty("Siblings");
            var currentValue = (IList) prop.GetValue(person);
            currentValue.Add("new object");
            Console.WriteLine(person.Siblings);
        }
    }
    public class Person {
        public Person() {
            Siblings = new ObservableCollection<string>();
        }
        public ObservableCollection<string> Siblings { get; private set; } 
    }
