	public class Logbook
	{
	  public Logbook(string username)
	  {
		this.CreatedBy = username;
		this.DateCreated = DateTime.UtcNow; //NB: ideally your database would provide this to ensure if deployed on multiple servers you'd have one date source
		this.ModifiedBy = username;
		this.DateModified = DateTime.UtcNow; //as above
	  }
	  public void Modify(string username)
	  {
		this.ModifiedBy = username;
		this.DateModified = DateTime.UtcNow; //as above
	  }
	  public string CreatedBy { get; set; }
	  public DateTimeOffset DateCreated { get; set; }
	  public string ModifiedBy { get; set; }
	  public DateTimeOffset DateModified { get; set; }
	}
	public class Customer
	{
	  private int id;
	  public int Id { 
		get { return this.id; } 
		set { this.id = value; this,OnCreateOrModify(); }
	  }
	  private string name;
	  public string Name { 
		get { return this.name; }
		set { this.name = value; this,OnCreateOrModify(); }
      }
	  public Logbook Logbook { get; private set; } //presumably you don't want other classes to amend this
	  private void OnCreateOrModify()
	  {
		var username = System.Environment.UserName;  //or pass something into your class contructor to provide a username
		if (this.Logbook == null) //create
			this.Logbook = new LogBook(username
		else //modify
			this.Logbook.Modify(username);
	  }
	}
