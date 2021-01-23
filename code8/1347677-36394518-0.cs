    namespace Seperation
    {
        class Program
        {
            static void Main()
            {
                string temp;
                string sentenceTwo = (" ");
                Console.WriteLine("please enter a sentence");
                temp = Console.ReadLine();
                sentenceTwo = temp;
                string[] split = sentenceTwo.Split(' ');
                foreach (string item in split)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();        
            }
        }
    }
