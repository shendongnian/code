    private static List<Question> unansweredQuestions; 
    
    ...
    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
    
        SetCurrentQuestion ();
    
    }
