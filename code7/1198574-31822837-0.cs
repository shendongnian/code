    void Main()
    {
    	var myQuery = new List<Car> { 
	        new Car {IsRed = true, IsConvertible = true },
        	new Car {IsRed = true, IsConvertible = false },
        	new Car {IsRed = false, IsConvertible = true },
        	new Car {IsRed = false, IsConvertible = false }
    	}.AsQueryable();
    	
	    Expression<Func<Car, bool>> isRed = c => c.IsRed;
    	Expression<Func<Car, bool>> isConvertible = c => c.IsConvertible;
    	var isRedConvertible = isRed.And(isConvertible);
    	
    	var redConvertible = myQuery.Where(isRedConvertible);
    }
    public class Car
    {
    	public bool IsRed {get;set;}
    	public bool IsConvertible {get;set;}
    }
