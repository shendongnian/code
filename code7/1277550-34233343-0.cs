    public class WebinarQuestion : IComparable<WebinarQuestion> {
        public string answer { get; set; }
        public string question { get; set; }
        public int CompareTo(WebinarQuestion other)
        { 
            QuestionNumber.CompareTo(other.QuestionNumber);
        }
        private int QuestionNumber { get { return Int32.Parse(question.Split('.')[0]); }}
    }
