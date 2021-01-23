    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sentence = "Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ";
                StringBuilder sb = new StringBuilder();
                int count = 0;
                var words = sentence.Split(' ');
                foreach (var word in words)
                {
                    if (count + word.Length > 25)
                    {
                        sb.Append(Environment.NewLine);
                        count = 0;
                    }
                    sb.Append(word + " ");
                    count += word.Length + 1;
                }
                Console.WriteLine(sb.ToString());
                Console.ReadKey();
            }
        }
    }
