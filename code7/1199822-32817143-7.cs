	public interface IVisitor 
	{
		void Visit(this MyAnotherClass c);
		void Visit(this MyClass c);
	}
	
	public abstract class MyBaseClass : IInvoker { public abstract void Accept(IVisitor visitor); }
    public class MyAnotherClass : MyBaseClass { public override void Accept(IVisitor visitor) { visitor.Visit(this); } }
	public class MyClass : MyBaseClass { public override void Accept(IVisitor visitor) { visitor.Visit(this); } }
