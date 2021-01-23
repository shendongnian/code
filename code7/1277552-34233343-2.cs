    public class WebinarQuestion : IComparable<WebinarQuestion> {
        public string answer { get; set; }
        public string question { get; set; }
        public int CompareTo(WebinarQuestion other)
        { 
            return QuestionNumber.CompareTo(other.QuestionNumber);
        }
        private int QuestionNumber 
        { 
            get 
            { 
                // Or write more robust parsing if format differs
                return Int32.Parse(question.Split('.')[0]); 
            }
        }
    }
