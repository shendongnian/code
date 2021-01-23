       [Serializable]
       public abstract class Quiz
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int CurrentQuestion { get; set; }
        }
 
       [Serializable]
       public class QuizWithQuestions : Quiz
        {
            public ICollection<Question> Questions { get; set; }
        }
