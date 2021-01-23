    using System;
    using AutoMapper;
    
    public class Foo
    {
    	public string A { get; set; }
    	public int B { get; set; }	
    }
    
    public class Bar
    {
    	public string A { get; set; }
    	public int B { get; set; }	
    }
    
    public class Program
    {
    	public static void Main()		
    	{
    		Mapper.CreateMap<Foo,Bar>();
    		
    		var foo = new Foo { A="test", B=100500 };
    		
    		var bar = Mapper.Map<Bar>(foo);
    		
    		Console.WriteLine("foo type is {0}", foo.GetType());
    		Console.WriteLine("bar type is {0}", bar.GetType());
    
    		Console.WriteLine("foo.A={0} foo.B={1}", foo.A, foo.B);
    		Console.WriteLine("bar.A={0} bar.B={1}", bar.A, bar.B);
    	}
    }
