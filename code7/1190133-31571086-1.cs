    QuestionRepository questionRepo = new QuestionRepository();
    AnswerRepository answerRepo = new AnswerRepository();
    List<Question> questions = questionRepo.getQuestions();
    List<Answer> answers = answerRepo.getAnswers();
    
    foreach(Question q in questions)
    {
       var q1 = new Question { ID = q.QuestionID, QuestionText = q.Description };
       List<Answer> questionAnswers = answers.FindAll(o => o.QuestionAnswerID == q.QuestionID);
        if(questionAnswers != null)
        {
            foreach(Answer a in questionAnswers)
            {
                q1.Answers.Add(new Answer { ID = a.AnswerID, AnswerText = a.Description });
                evalVM.Questions.Add(q1); 
            }
        }
        return evalVM;
    }
