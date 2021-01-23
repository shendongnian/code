    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    public class Test {
    	public static void Main()
    	{
    		var t = new Test1();
    		t.Play();
    	}
    
    }
    public interface IMovable
    {
        // I define the default parameters in only one place
        void Move(int direction = 90, int speed = 100);
    }
    
    public class Test1 : IMovable{
    	public void Move (int direction, int speed)
    	{
    		Console.Write($"{direction} {speed}");
    	}
    	
    	public void Play (){
    		((IMovable)this).Move();
    	}
    }
