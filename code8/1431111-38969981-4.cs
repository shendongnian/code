    using System;
    using AutoMapper;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => { 
    			cfg.CreateMap<MyClass1, MyClass2>(); // call initialise once...
    			cfg.CreateMap<MyClass3, MyClass4>(); 
    		});
    
            var dto = new MyClass1();
            Mapper.Map<MyClass1, MyClass2>(dto);
    		
    		Console.WriteLine("Made it");
        }
    }
    
    public class MyClass1
    {
    }
    
    public class MyClass2
    {
    }
    
    public class MyClass3
    {
    }
    
    public class MyClass4
    {
    }
