	public interface IClass
	{
		string Test { get; }
	}
	
	public class Class1 : IClass
	{
		public string Test
		{
			get { return "Class1"; }
		}
	}
	
	public class Class2 : IClass
	{
		public string Test
		{
			get { return "Class2"; }
		}
	}
	IClass[] Objects = new IClass[2];
	Objects[0] = new Class1();
	Objects[1] = new Class2();
