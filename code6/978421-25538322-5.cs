	public class CustomODataSerializerProvider : DefaultODataSerializerProvider
	{
		public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
		{
			if(edmType.Definition.TypeKind == EdmTypeKind.Entity)
				return new CustomODataEntityTypeSerializer(this);
			else 
				return base.GetEdmTypeSerializer(edmType);
		}
	}
