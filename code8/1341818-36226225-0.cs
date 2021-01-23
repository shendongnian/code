    using System;
    using System.Collections.Generic;
    
    class A {
        public string X {get; set;}
        public string Y {get; set;}
    	public override string ToString() {
    		return "X: " + this.X + " Y: " + this.Y;
    	}
     }
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<A> list = Create<A>("X", new string[] {"value1", "value2"});
    		foreach(A item in list) {
    			Console.WriteLine(item.ToString());
    		}
    		list = Create<A>("Y", new string[] {"valueY1", "valueT2"});
    		foreach(A item in list) {
    			Console.WriteLine(item.ToString());
    		}
    	}
      public static List<T> Create<T>(string attr, string[] attrValues) where T: new()
        {
            //I want to check if T has attribute attr (let's say "X")
    
            List<T> ret = new List<T>();
            foreach (string value in attrValues)
            {
                T t = new T();
    			
    
                foreach (var property in typeof(T).GetProperties())
                {
                    if (property.Name == attr) // setting value for x
                    {
                        property.SetValue(t, "Value");
    				}
                }
                ret.Add(t);
            }
            return ret;
        }
    }
