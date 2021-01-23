    class Question{
    	public string QuestionText {get; set;}
    	public ICollection<string> AnswerChoices {get; set;}
    	public string CorrectAnswer {get; set;}
    	public string AnswerProvided {get;set;}
    }
    
    public decimal GradeQuiz(ICollection<Question> questions){
    	
    	if(questions.Count == 0){
    		throw new InvalidOperationException("Cannot grade a quiz with no questions");
    	}
    	
    	var correct = questions.Count(x => x.AnswerProvided == x.CorrectAnswer);
    	var total = questions.Count;
    	return (decimal)correct * 100 / total;
    }
