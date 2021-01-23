    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string input = Console.ReadLine();
            //split the input string into an array
            string[] arrInput = input.Split(' ');
            //this loop decide letter combination
            for (int i = 2; i <= arrInput.Length; i++)
            {
                //this loop decide how many outputs we would get for a letter combination
                //for ex. we would get 2 outputs in a 3 word string if we combine 2 words
                for (int j = i-1; j < arrInput.Length; j++)
                {
                    int end = j; // end index
                    int start = (end - i) + 1; //start index
                    string output = Combine(arrInput, start, end);
                    Console.WriteLine(output);
                }
            }
            Console.ReadKey();
        }
        
        //combine array into a string with space except from start to end
        public static string Combine(string[] arrInput, int start, int end) {
            StringBuilder builder = new StringBuilder();
            bool combine = false;
            for (int i = 0; i < arrInput.Length; i++) {
                //first word in the array... don't worry
                if (i == 0) {
                    builder.Append(arrInput[i]);
                    continue;
                }
                //don't append " " if combine is true
                combine = (i > start && i <= end) ? true : false;
                if (!combine)
                {
                    builder.Append(" ");
                }
                builder.Append(arrInput[i]);
            }
            return builder.ToString();
        }
    }
