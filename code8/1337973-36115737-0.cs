    public class Parent
	{
		public int X { get; set; }
	}
	public class Child : Parent
	{
		public int Y { get; set; }
	}
	public class ClassXCompare : IEqualityComparer<Parent>
	{
		public bool Equals(Parent x, Parent y)
		{
			var child = y as Child;
			return child != null && x.X == child.Y;
		}
		public int GetHashCode(Parent parent)
		{
			var c = parent as Child;
			if (c == null)
				return parent.X.GetHashCode();
			else
				return c.Y.GetHashCode();
		}
	}
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var parentList = new List<Parent>
				{
						new Parent {X = 5},
						new Parent {X = 6}
				};
			var childList = new List<Child>
				{
						new Child {Y = 5},
						new Child {Y = 6}
				};
			var compare = new ClassXCompare();
			var diff = childList.Except(parentList, compare);
			Assert.IsTrue(!diff.Any()); // Fail ???		
		}
	}
