    public class Question // Class names should be a singular form noun
    {
        public int Id { get; set; } // QuestionId is redundant
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    var questions = new Question[]
    {
        new Questions {Id = 1, Question = "How old are you?", Answer = "32"},
        new Questions {Id = 2, Question = "What is your name?", Answer = "John"},
        new Questions {Id = 3, Question = "How tall are you?", Answer = "6'"}
    }.ToDictionary(q => q.Id, q => q);
    var answerToQuestionNumberTwo = questions[2].Answer;
