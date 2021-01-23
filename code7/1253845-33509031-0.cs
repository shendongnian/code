    public interface ICopyTo<T>
    {
    	T CopyTo(T target);
    }
    
    public abstract class Person : ICopyTo<Person>
    {
    	public virtual Person CopyTo(Person person)
    	{
    		person.Age = Age;
    		person.Country = Country;
    		return person;
    	}
    
    	public int Age { get; set; }
    	public string Country { get; set; }
    }
    
    public abstract class Adult : Person, ICopyTo<Adult>
    {
    	public virtual Adult CopyTo(Adult adult)
    	{
    		base.CopyTo(this);
    		adult.Car = Car;
    		return adult;
    	}
    
    	public string Car { get; set; }
    }
    
    public class Man : Person, ICopyTo<Man>
    {
    	public virtual Man CopyTo(Man man = null)
    	{
    		if (man != null)
    		{
    			man = new Man();
    		}
    		base.CopyTo(this);
    		man.Beer = Beer;
    
    		return man;
    	}
    
    	public string Beer { get; set; }
    }
    
    public class Woman : Person, ICopyTo<Woman>
    {
    	public virtual Woman CopyTo(Woman woman = null)
    	{
    		if (woman == null)
    		{
    			woman = new Woman();
    		}
    		base.CopyTo(this);
    		woman.Purse = Purse;
    		return woman;
    	}
    
    	public string Purse { get; set; }
    }
    
    public class Test
    {
    	public void Go()
    	{
    		Man man1 = new Man() {Age = 10, Beer = "Bud", Country = "Canada"};
    		Man man2 = new Man();
    		man1.CopyTo(man2); // Real copy
    
    		Woman woman1 = new Woman() {Age = 32, Country = "USA", Purse = "Anything"};
    		Woman woman2 = woman1.CopyTo(); // Cloning
    	}
    }
