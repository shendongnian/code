    public class Program {
        public static void Main() {
            var test = Test.Instance; // good
            var other = new Test(); // less than ideal
        }
    }
