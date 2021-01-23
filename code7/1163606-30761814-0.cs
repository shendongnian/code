    public interface IIdentifier
    {
        int Id { get; }
    }
	public class BaseClass { }
    public class ClassWithId<T> : BaseClass where T :  IIdentifier, new()
    {
		public static int Id { get { return (new T()).Id; } }
    }
	public struct StaticId1 : IIdentifier
	{
		public int Id { get { return 1; } }
	}
	
	public struct StaticId2 : IIdentifier
	{
		public int Id { get { return 2; } }
	}
    //Testing
    Console.WriteLine(ClassWithId<StaticId1>.Id);   //outputs 1
	Console.WriteLine(ClassWithId<StaticId2>.Id);   //outputs 2
