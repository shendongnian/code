    public class ColumnIsNotNullByDefaultConvention : IPropertyConvention, IPropertyConventionAcceptance
	{
		public void Apply(IPropertyInstance instance)
		{
			instance.Not.Nullable();
		}
		public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
		{
			criteria.Expect(c => !(
				                      c.Property.MemberInfo.IsDefined(typeof (NullableAttribute), false) ||
				                      IsNullableType(c.Property.PropertyType))
				);
		}
		private bool IsNullableType(Type type)
		{
			return
				(type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof (Nullable<>))) ||
				Nullable.GetUnderlyingType(type) != null;
		}
	}
