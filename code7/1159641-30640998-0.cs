    public class QuestionResult
    {
       //If a QuestionResult requires a User, then the foreign key should be an int
       //If a QuestionResult is valid without a User, then change the foreign key 
       //to a nullable int
       public int UserId { get; set; }
    
       public virtual ApplicationUser User { get; set; }
    }
