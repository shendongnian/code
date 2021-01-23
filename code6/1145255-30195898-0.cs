    public class Question {
        public Question() {
           Answers = new AnswerObjectCollection();
        }
        public AnswerObjectCollection Answers {
            get;
            private set;
        }
    }
