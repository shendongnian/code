    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
        public class Question
        {
            private static Random rand = new Random();
            public static List<Question> questions { get; set; }
            public string question { get; set; }
            public int randomNumber { get; set; }
            public void Shuffle()
            {
                foreach(Question question in questions)
                {
                    question.randomNumber = rand.Next();
                }
                questions = questions.OrderBy(x => x.randomNumber);
            }
        }
    }
