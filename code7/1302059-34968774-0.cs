    for (int i = 0; i < 40; i++)
    {
        Questions.Add(new Question
        {
            QuestionString = GlobalClass.RandomString(40),
            Answers = Enumerable.Range( 0,4 ).Select( x=>new Answer {
                Id = x
            }).ToList()
        });
    }
