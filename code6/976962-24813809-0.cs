    public class AgeWrapper {
        public int Age { get; set; }
        public AgeWrapper( int age ) { this.Age = age; }
    }
    public void DoWork() {
       AgeWrapper a = new AgeWrapper(21);
       AgeWrapper b = new AgeWrapper(21);
       AgeWrapper c = a;
       Console.WriteLine( a.Equals(b) ); // prints false;
       Console.WriteLine( a.Equals(c) ); // prints true;
    }
