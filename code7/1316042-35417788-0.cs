    public class OrderCustomization : ICustomization
    {
    	public void Customize(IFixture fixture)
    	{
    		fixture.Customizations.Add(
    			new TypeRelay(
    				typeof(IOrder),
    				typeof(Order)));
    	}
    }
