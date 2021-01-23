	public class ClassA
	{
        int num = 10;
        public static List<ClassA> Objects { get; } = new List<ClassA>();
		public ClassA()
		{
			objects.Add(this);
		}
	}
