    public class ViewModel
    {
        public ICommand TestCommand { get; set; }
        public ViewModel()
        {
            TestCommand = new TestCommand(this);
        }
        public void FeedbackPanel(string text)
        {
            if (text != null)
            {
                if (text != null)
                {
                    text += (text + "\n");
                }
                else
                {
                    text += ("Null\n");
                }
            }
            else
            {
                return;
            }
        }
    }
