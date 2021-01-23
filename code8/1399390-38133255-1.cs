    [Serializable]
    public class QuizQuestionsLoader : IDialog<int>
    { 
        public static int Score { get; private set; }
        private IList<QuizQuestion> problems;
        private QuizQuestion theQuestion;
        private int index;      
        private int jokerCount = 2;
        private const string jokerAnswerText = "Utiliser un joker";
        public QuizQuestionsLoader(IList<QuizQuestion> problems)
        {
            this.problems = problems;
        }
