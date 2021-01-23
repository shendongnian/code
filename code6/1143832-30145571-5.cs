    public class Logic
    {
        public List<string> AllQuestionsInRandomOrder { get; set; } 
        public List<string> QuestionsThatHaveBeenRemoved { get; set; }
        public Logic()
        {
            QuestionsThatHaveBeenRemoved = new List<string>();
            AllQuestionsInRandomOrder = GetQuestionsInRandomOrder().ToList();
        }
        public string GetUnusedQuestion()
        {
            var question =
                AllQuestionsInRandomOrder.FirstOrDefault(x => !QuestionsThatHaveBeenRemoved.Contains(x));
            QuestionsThatHaveBeenRemoved.Add(question);
            return question;
        }
        public IEnumerable<string> GetQuestionsInRandomOrder()
        {
            var lines = File.ReadAllLines("test.txt").ToList();
            var rnd = new Random();
            lines = lines.OrderBy(line => rnd.Next()).ToList();
            return lines;
        }
        public void RemoveQuestion(List<string> questions, string questionToRemove)
        {
            questions.Remove(questionToRemove);
        }
    }         
