    using System;
    using System.Collections.Generic;
    
    class Base {}
    class ClassOne : Base {
    	public void doOne(){
           Console.WriteLine("doing one") ;
    	}
    }
    
    class ClassTwo : Base {
    	public void doTwo(){
       		Console.WriteLine("doing two");
    	}
    	
    }
    class ClassThree : Base {
    	public void doThree(){
    			Console.WriteLine("doing three");
    		}
    }
    
    
    class MainClass {
    	
      static Base[] objects = {
      	new ClassOne(),
     	new ClassTwo(),
     	new ClassThree()
      	
      };	
     
      public static void Main (string[] args) {
      	
      	Action<ClassOne> ClassOneFunc = delegate(ClassOne o)
             {o.doOne();}; 
        Action<ClassTwo> ClassTwoFunc = delegate(ClassTwo o)
             { o.doTwo();}; 
        Action<ClassThree> ClassThreeFunc = delegate(ClassThree o)
             { o.doThree();};   
             
        var contents = new Dictionary<System.Type, Action<dynamic>>
        	{
        		{typeof(ClassOne), ClassOneFunc}, 
        		{typeof(ClassTwo), ClassTwoFunc},
        		{typeof(ClassThree), ClassThreeFunc},
        		
        	};
        	
        Action<dynamic> worker = o => contents[o.GetType()](o);	
    
             
    
      	
      	
      foreach(var each in objects){
      	worker(each);
      	
      }
    }}
