	public class MyClassType {
		public long Property { get; set; }
	}
	public interface IFoo {
		void DoThing(int i, Expression<Func<MyClassType, long>> expression);
	}
	[Test]
	public void ReceivedWithAnyExpression() {
		var myObj = Substitute.For<IFoo> ();
		myObj.DoThing (10, x => x.Property);
		myObj.Received(1).DoThing(Arg.Is(10), Arg.Any<Expression<Func<MyClassType, long>>>());
	}
