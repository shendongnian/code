	public class AttributeApplication
	{
		[YourAttribute]
		public void NormalMethod()
		{
		}
		
		[YourAttribute(doSomethingDifferent: true)]
		public void MethodSomewhatDifferent()
		{
		}
	}
