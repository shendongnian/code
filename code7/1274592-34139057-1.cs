    List<SimpleQuestion> listOfQ = new List<SimpleQuestion>();
                listOfQ.Add(new SimpleQuestion(1, "1"));
                listOfQ.Add(new SimpleQuestion(2, "2"));
                listOfQ.Add(new SimpleQuestion(3, "3"));
    
                List<Question> testQuestions = new List<Question>();
                testQuestions.Add( new Question(1,1,"1"));
                testQuestions.Add( new Question(2,2,"2"));
                testQuestions.Add( new Question(3,3,"1"));
    
    
                List<Question> list = (from q in listOfQ
                                       join a in testQuestions on q.IdQuestion equals a.IdQuestion
                                       where a.Answer == q.Answer
                                       select a
                                          ).ToList();
