    class Answer
    {
        public string Text { get; set; }
        public bool Correct { get; set; }
    }
    
    class Question
    {
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
    }
    
    void Main()
    {
        var test = new List<Question>
        {
            new Question 
            { 
                QuestionText = "What colour is the sky?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Blue", Correct = true },
                    new Answer { Text = "Red", Correct = false },
                    new Answer { Text = "Green", Correct = false }
                }
            },
            new Question
            {
                QuestionText = "Which animals can swim?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Ducks", Correct = true },
                    new Answer { Text = "Fish", Correct = true },
                    new Answer { Text = "Horses", Correct = false }
                }
            }
        };
        
        // do stuff with the test
    }
    
