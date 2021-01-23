      public int CheckedIndex { get { return rbAnswers.SelectedIndex; } }
        public ScoringQuestion scoringQuestion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Reinitialize();
        }
        public void Reinitialize()
        {
            if (scoringQuestion != null)
            {
                foreach (string item in scoringQuestion.GetAnswersAsList())
                {
                    rbAnswers.Items.Add(new ListItem(item));
                }
                lblQuestion.Text = scoringQuestion.GetQuestionText();
            }
        }
