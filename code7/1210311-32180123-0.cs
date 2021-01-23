	public class AddressService
	{
		public Address CreateAddress(Expression<Func<Address, Guid?>> idPropertySelector)
		{
            // So you get the property info to later set it using reflection
			MemberExpression propertyExpr = (MemberExpression)idPropertySelector.Body;
			PropertyInfo property = (PropertyInfo)propertyExpr.Member;
            // Then you create an instance of address...
			Address address = new Address();
            // and you set the property using reflection:
			property.SetValue(address, (Guid?)Guid.NewGuid());
			return address;
		}
	}
