    public class Answer2 {
        private bool correct;  // This field has no need to be nullable
        public bool? Correct
        {
            get { return correct; }
            set { correct = value.GetValueOrDefault(); }
        }
    }
