    public class Person
    {
    	public Person(string name, int age)
    	{
    		Age = age;
    		Name = name;
    	}
    	
    	public int Age { get; set; }
    	public string Name { get; set; }
    }
    private static void Main(string[] args)
    {
	   Stopwatch sw = new Stopwatch();
	   sw.Start();
       for (int i = 0; i < 1000000; i++)
	   {
		  Person p = new Person("John", 35);
		  var age = p.Age;
		  var name = p.Name;
	   }
	
	   Console.WriteLine("Loop with inner allocation took {0}", m sw.Elapsed);
	
	   sw.Restart();
	   Person px = new Person("John", 35);
	   for (int i = 0; i < 1000000; i++)
	   {
	   	  var age = px.Age;
		  var name = px.Name;
	   }
	   Console.WriteLine("Loop with outter allocation took {0}", sw.Elapsed)
    }
