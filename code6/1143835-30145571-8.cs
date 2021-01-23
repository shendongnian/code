    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var questions = new Questions();
                var firstQuestion = questions.GetUnusedQuestion();
                Console.WriteLine(firstQuestion);
            }
        }
    
        class Questions
        {
    
            public string FileName { get; set; }
            public static List<string> AllQuestionsAndAnswersFromFile { get; set; } 
            public List<string> AllQuestionsInRandomOrder { get; set; }
            public List<string> QuestionsThatHaveBeenRemoved { get; set; }
    
            public Questions()
            {
                FileName = "text.txt";
                QuestionsThatHaveBeenRemoved = new List<string>();
                AllQuestionsAndAnswersFromFile = new List<string>();
                ReadQuestionsFromFile();
                AllQuestionsInRandomOrder = GetQuestionsInRandomOrder().ToList();
            }
    
            public string GetUnusedQuestion()
            {
                var question =
                    AllQuestionsInRandomOrder.FirstOrDefault(x => QuestionsThatHaveBeenRemoved.Contains(x));
                QuestionsThatHaveBeenRemoved.Add(question);
                return question;
            }
    
            private static IEnumerable<string> GetQuestionsInRandomOrder()
            {
                var lines = AllQuestionsAndAnswersFromFile;
                var rnd = new Random();
                lines = lines.OrderBy(line => rnd.Next()).ToList();
                return lines;
            }
    
            public void RemoveQuestion(List<string> questions, string questionToRemove)
            {
                questions.Remove(questionToRemove);
            }
     
            public void ReadQuestionsFromFile()
            {
                using (var reader = new StreamReader(FileName, Encoding.Default))
                {
                    var text = reader.ReadToEnd();
                    var lines = text.Split('=');
                    foreach (var s in lines)
                    {
                        AllQuestionsAndAnswersFromFile.Add(s);
                    }
                }
            }
        }
    }
