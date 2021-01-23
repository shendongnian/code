    static void Main(string[] args)
            {
                string input = Console.ReadLine();
                int[] vec = new int[input.Length]; 
                int i = 0;
                foreach (char ch in input) {
                    vec[i] = Convert.ToInt32(ch.ToString());
                    i++;
                }
    
                foreach (int numaux in vec) {
                    Console.WriteLine(numaux);
                }
                Console.Read();
            }
