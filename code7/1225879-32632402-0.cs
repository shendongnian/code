    public class Program
    {
        public static void Main(string[] args)
        {
            string sentence = "Example sentence";
            string[] array = sentence.Split(' ');
            
            foreach (string val in array.Where(i => !string.IsNullOrEmpty(i)))
            {
                Console.WriteLine(val);
            }
        }
    }
