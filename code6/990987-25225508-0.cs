    // GET: api/Questions
    [HttpGet]
    public IList<QuestionResponse> Getquestions()
    {
        return db.questions.Select(x => new QuestionResponse
        {
            Id = x.Id,
            Question = x.Question
        });
    }
    
    
    public class QuestionResponse
    {
      public int Id {get;set;}
      public string Question {get;set;}
    }
