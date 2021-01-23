    using System;
    using System.Threading.Tasks;
    namespace FunWithThreading
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sentence =
                    "I am going to add each of these words to a string "
                    + "using multiple threads just to see what happens.";
                var words = sentence.Split(' ');
                var output = "";
                Parallel.ForEach(words, word => output = output + " " + word);
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
