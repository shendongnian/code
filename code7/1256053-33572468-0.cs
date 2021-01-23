    public struct pair
	{
		float x, y;
		public pair(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
	}
	public class MyClass
	{
		public static readonly pair[] lookup;
        static MyClass()
		{
			lookup = new pair[7] { new pair(1, 2), new pair(2, 3), new pair(3, 4), new pair(4, 5), new pair(5, 6), new pair(6, 7), new pair(7, 8) };
		}
	}
