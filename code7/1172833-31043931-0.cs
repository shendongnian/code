    public class CheckState
    {
        public bool IsChecked { get; set; }
        public CheckState(bool isChecked)
        {
            this.IsChecked = isChecked;
        }
    }
    public class Model
    {
        public bool[] CheckStates { get; set; }
    }
