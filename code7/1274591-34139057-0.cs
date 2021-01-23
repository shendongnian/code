    public class Question
        {
            public int Iduser;
            public int IdQuestion;
            public string Answer;
            public Question(int iduser,int idquestion,string answer)
            {
                this.Iduser = iduser;
                this.IdQuestion = idquestion;
                this.Answer = answer;
            }
        }
    public class SimpleQuestion
    {
        public int IdQuestion;
        public string Answer;
        public SimpleQuestion(int idquestion, string answer)
        {
            this.IdQuestion = idquestion;
            this.Answer = answer;
        }
    }
