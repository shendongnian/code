    static void Main()
	{
      List<MyObject> myListOfObjects = fillArray();
	  DisplaySortedArray(myListOfObjects);
	  Console.ReadLine();
    }
    
    public static void DisplaySortedArray(List<MyObject> myListOfObjects)
    {
      foreach(var myObject in myListOfObjects)
	  {
		  Console.WriteLine(myObject.Property1);
		  Console.WriteLine(myObject.Property2);
		  Console.WriteLine(myObject.Property3);
		  Console.WriteLine(myObject.Property4);
		  Console.WriteLine(myObject.Property5);
		  Console.WriteLine(myObject.Property6);
	  }
    }
    public static List<MyObject> fillArray()
    {
        string[] linesInFile = File.ReadAllLines(GlobalVariables.filePath);
		List<MyObject> myListOfObjects = new List<MyObject>();
		
        foreach (string s in linesInFile)
        {
            string[] items = s.Split(';');
            MyObject myObject = new MyObject();
			myObject.Property1 = items[0];
			myObject.Property2 = items[1];
			myObject.Property3 = items[2];
			myObject.Property4 = items[3];
			myObject.Property5 = items[4];
			myObject.Property6 = items[5];
			myListOfObjects.Add(myObject);
        }
		
		return myListOfObjects;
    }
    public class MyObject
    {
		public string Property1 {get;set;}
		public string Property2 {get;set;}
		public string Property3 {get;set;}
		public string Property4 {get;set;}
		public string Property5 {get;set;}
		public string Property6 {get;set;}
    }
