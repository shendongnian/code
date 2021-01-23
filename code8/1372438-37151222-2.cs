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
    public abstract class  IMovable
    {
        // I define the default parameters in only one place
        public abstract void Move(int direction, int speed);
    	
    	public void Move(){
    		this.Move(90, 100);
    	}
    }
    
    public class Test1 : IMovable{
    	
    	public virtual void Move(int direction, int speed){
    		
    		Console.Write($"{direction} {speed}");
    	}
    	
    	public void Play (){
    		this.Move();
    	}
    }
