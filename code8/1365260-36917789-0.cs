    public class Quiz
    {
        public string Name { get; set; }
        public List<QuizQuestion> Questions { get; set; }
    }
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> IncorrectAnswers { get; set; }
        public bool checkAnswer(string answer)
        {
            return answer == CorrectAnswer;
        }
        private List<string> generateAnswerList()
        {
            List<string> ret = IncorrectAnswers.ToList();
            ret.Add(CorrectAnswer);
            ret.OrderBy(a => Guid.NewGuid());
            return ret;
        }
        public string generateHTML()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("<div>"+Question+"</div>");
            foreach (string answer in generateAnswerList())
            {
                ret.Append(String.Format(@"<input name='{0}' type='radio' value='{1}'/>{1}<br/>", Question,answer));
            }
            return ret.ToString();
        }
    }
