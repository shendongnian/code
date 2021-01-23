    public class CustomParameterBindingAttribute : ParameterBindingAttribute
	{
		public override HttpParameterBinding GetBinding( HttpParameterDescriptor parameter )
		{
			return new CustomParameterBinding( parameter );
		}
	}
