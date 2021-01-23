    public class Car
    {
    	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int IdCar { get;set; }
    
    	public string ColorCode { get; set; }
    
    	[Index(IsUnique = true)]
    	public string MotorId { get; set; }
    	
    	//By having this update function alongside the members, it's easy to see whether it's up to date.
    	public void Update(Car original)
    	{
    		original.ColorCode = ColorCode;
    		original.MotorId = MotorId;
    	}
    }
    
    public static int UpsertCar(Car checkCar, MyContext db)
    {
    	var original = db.Cars.SingleOrDefault(c => c.IdCar == checkCar.IdCar);
    	
    	if (original == null)
    	{
    		db.Cars.Add(checkCar);
    	}
    	else
    	{
    		checkCar.Update(original);
    	}
    	db.SaveChanges();
    }
