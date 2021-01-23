	public class MyViewModel
	{
	  public List<PersonInfo> DataItems { get; }
	    = new List<PersonInfo>()
	      {
	        new AgeInfo() { Age = 25 },
	        new NameInfo() { Name = 13 }
	      };
	}
	
	public abstract class PersonInfo
	{
	}
	
	public class AgeInfo : PersonInfo
	{
	  public int Age { get; set; }
	}
	
	public class NameInfo : PersonInfo
	{
	  public int Name { get; set; }
	}
