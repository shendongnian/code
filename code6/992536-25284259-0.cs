	public class LetterInfo
	{
	   public List<Recipient> Recipients {get; set;}
	   public string Paragraph1 {get; set;}
	   public string Paragraph2 {get; set;}
	   public string Paragraph3 {get; set;}
	   etc
	   
	   public LetterInfo(){
	    Recipients = new List<Recipient>();
	   }
	}
	
	public class Recipient
	{
	   public string FirstName {get; set;}
	   public string LastName {get; set;}
	   public string MiddleName {get; set;}
	}
