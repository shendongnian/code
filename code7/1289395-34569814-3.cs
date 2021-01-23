    public class DataBaseInitializer
    {
        public void Seed(IQuestionRepository questionRepository, DummyAnswerRepository answerRepository)
        {
            var q1 = new Question { Value = "Favourit food?" };
            var q2 = new Question { Value = "Who is the president?" });
            var q3 = new Question { Value = "Favourit movie?" });
            questionRepository.Create(q1);
            questionRepository.Create(q2);
            questionRepository.Create(q3);
            answerRepository.Create(new Answer { Value = "pizza", Question = q1 });
            answerRepository.Create(new Answer { Value = "fries", Question = q1 });
            answerRepository.Create(new Answer { Value = "Bush", Question = q2 });
            answerRepository.Create(new Answer { Value = "Obama", Question = q2 });
            answerRepository.Create(new Answer { Value = "titanic", Question = q3 });
            answerRepository.Create(new Answer { Value = "lion king", Question = q3 });
        }
    }
