    public class QuestionAndAnswers
    {
       private readonly Dictionary<int, string> _answers;
       public string Question { get; set; }
       public Dictionary<int, string> Answers { get { return _answers; } }
       public int CorrectAnswer { get; set; }
       // Perhaps add a grade/points enumeration and a property to use it here,
       // if some questions are worth more than others
       public QuestionAndAnswers()
       {
          // You would probably want to provide arguments to the constructor
          // and make the class immutable
          _answers = new Dictionary<int, string> ();
       }
    }
