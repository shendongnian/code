    public class AdminTestDto 
    {
    	public int AdminTestId { get; set; }
    	public string Title { get; set; }
    	public int AdminTestQuestionId { get; set; }
    	public int QuestionUId { get; set; }
    	public string QuestionTitle { get; set; }
    	public int SubTopicId { get; set; }
    
    	public AdminTestDto(AdminTest a)
    	{
    		this.AdminTestId = a.AdminTestId;
    		this.Title = a.Title;
    		this.AdminTestQuestionId = a.AdminTestQuestion.AdminTestQuestionId;
    		this.QuestionUId = a.AdminTestQuestion.QuestionUId;
    		this.QuestionTitle = a.AdminTestQuestion.Question.Title;
    		this.SubTopicId = a.AdminTestQuestion.Question.Problem.SubTopicId;
    	}
    }
