    using System;
	using System.Collections.Generic;
	public class TestObject
	{
		private TestObjectCollection _testObjects;
		public string name { get; set; }
		public TestObjectCollection parentCollection { get; set; }
		public TestObjectCollection testObjects 
		{ 
			get
			{
				return _testObjects;
			}
			set 
			{
				_testObjects = value;
				_testObjects.parent = this;
			}
		}
	}
	public class TestObjectCollection
	{
		private List<TestObject> _testObjects;
		public TestObject parent { get; set; }
		
		public TestObjectCollection()
		{
			_testObjects = new List<TestObject>();
		}
		
		public void Add(TestObject testObject)
		{
			testObject.parentCollection = this;
			_testObjects.Add(testObject);
		}
		
		public TestObject this[int i] {
			get {
				return _testObjects[i];
			}
		}
	}
	public class Test
	{
		public static void Main()
		{
			// your code goes here
			TestObject test1 = new TestObject();
			
			TestObject test2 = new TestObject();
			
			var collection = new TestObjectCollection();
			collection.Add(test2);
			test1.testObjects = collection;
			
			if (test2.parentCollection.parent == test1)
			{
				Console.WriteLine("Done");
			}
			else
			{
				Console.WriteLine("Fail");
			}
		}
	}
