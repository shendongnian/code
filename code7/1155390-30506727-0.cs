    private string _currentQuestion = String.Empty;
    private void buttonHi_Click(object sender, EventArgs e)
       {
        string[] Hi = new string[]
        {"How are you?", "What's up?", "How have you been?"};
        Random X = new Random();
        _currentQuestion = Hi[X.Next(0, Hi.Length)];
        TextBox.Text = _currentQuestion;
        Clipboard.SetText(TextBox.Text);
       }
        private void buttonQuestion_Click(object sender, EventArgs e)
       {
        string[] Question = new string[]
        {"Are you busy?", "What are you doing?", "Sleeping?"};
        Random X = new Random();
        string Hi = Question[X.Next(0, Question.Length)];
        String.Format("{0} {1}", _currentQuestion, Question)
        Clipboard.SetText(TextBox.Text);
       }
