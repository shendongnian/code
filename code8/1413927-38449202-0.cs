    Question question1 = new Question(); // only 1 question
    
    List<Question> questions = new List<Question>(2);
    questions.Add(new Question());  // 1st question added
    questions.Add(new Question());  // 2nd question added
    
    // access the second question by:
    Question secondQuestion = questions[1];
    
