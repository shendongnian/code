    public class BaseGame<T> where T : BaseQuestion
    {
        private List<T> Questions { get; set; }
        public void AddQuestion(T question) { Questions.Add(question); }
    }
    var game = new BaseGame<Question> { Questions = new List<Question> };
    game.AddQuestion(new Question());
