	class java
	{
		public int count(int [,] list,int n)
		{
			int c = 0;
			for (int i = 0; i < list.GetLength(0); i++)
			{
				for (int j = 0; j < list.GetLength(1); j++)
				{
					if (list[i, j] == n)
					{
						c++;
					}
				}
			}
			return c;
		}
	
	class Program
	{
		static void Main(string[] args)
		{
			java jv = new java();
			int[,] arr = { {3,5,7,94 }, {5,6,3,50 } };
			int k=5;
			Console.WriteLine(jv.count(arr,k));
		}
	}
