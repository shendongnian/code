    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var num = new Number();
    		num.numberChanged +=(s,e) =>{
    			Console.WriteLine("Value was changed from to {0}",num.Value);
    		};
    		num.Value=10;
    		num.Value=100;
    	}
    }
    
    public class Number{
    	public event EventHandler numberChanged;
    	private int _value=0;
    	public int Value
    	{
    		get{
    			return _value;
    		}
    		set{
    			if(value!=_value){
    				_value=value;
    				if(numberChanged!=null)
    					numberChanged(this,null);
    			}
    		}
    	}
    }
