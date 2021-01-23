	[TestFixture]
	public static class MyTakeLastExtensions
	{	
		/// <summary>
		/// Intent: Returns the last N elements from an array.
		/// </summary>
		public static T[] MyTakeLast<T>(this T[] source, int n)
		{
			if (source == null)
			{
				throw new Exception("Source cannot be null.");
			}
			if (n < 0)
			{
				throw new Exception("Index must be positive.");
			}
			if (source.Length < n)
			{
				return source;
			}
			var result = new T[n];
			int c = 0;
			for (int i = source.Length - n; i < source.Length; i++)
			{
				result[c] = source[i];
				c++;
			}
			return result;
		}
	
		[Test]
		public static void MyTakeLast_Test()
		{
			int[] a = new[] {0, 1, 2};
			{
				var b = a.MyTakeLast(2);
				Assert.True(b.Length == 2);
				Assert.True(b[0] == 1);
				Assert.True(b[1] == 2);
			}
	
			{
				var b = a.MyTakeLast(3);
				Assert.True(b.Length == 3);
				Assert.True(b[0] == 0);
				Assert.True(b[1] == 1);
				Assert.True(b[2] == 2);
			}
	
			{
				var b = a.MyTakeLast(4);
				Assert.True(b.Length == 3);
				Assert.True(b[0] == 0);
				Assert.True(b[1] == 1);
				Assert.True(b[2] == 2);
			}
	
			{
				var b = a.MyTakeLast(1);
				Assert.True(b.Length == 1);
				Assert.True(b[0] == 2);
			}
	
			{
				var b = a.MyTakeLast(0);
				Assert.True(b.Length == 0);
			}
	
			{				
				Assert.Throws<Exception>(() => a.MyTakeLast(-1));
			}
	
			{
				int[] b = null;
				Assert.Throws<Exception>(() => b.MyTakeLast(-1));
			}
		}
	}
