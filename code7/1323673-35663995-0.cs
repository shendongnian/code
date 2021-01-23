    public interface ISmth
    {
    	void MyMethod();
    }
    
    class Car
    {
    }
    
    class MyCar : Car, ISmth
    {
    	public void MyMethod()
    	{
    	}
    }
