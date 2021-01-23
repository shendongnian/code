    > Inherit from `Microsoft.AspNet.OData.Formatter.Serialization.DefaultODataSerializerProvider`
        /// <summary>
        /// Provider that selects the IngoreNullEntityPropertiesSerializer that omits null properties on resources from the response
        /// </summary>
        public class IngoreNullEntityPropertiesSerializerProvider : DefaultODataSerializerProvider
        {
            private readonly IngoreNullEntityPropertiesSerializer _entityTypeSerializer;
            public IngoreNullEntityPropertiesSerializerProvider(IServiceProvider rootContainer)
                : base(rootContainer) {
                _entityTypeSerializer = new IngoreNullEntityPropertiesSerializer(this);
            }
            public override ODataEdmTypeSerializer GetEdmTypeSerializer(Microsoft.OData.Edm.IEdmTypeReference edmType)
            {
                // Support for Entity types AND Complex types
                if (edmType.Definition.TypeKind == EdmTypeKind.Entity || edmType.Definition.TypeKind == EdmTypeKind.Complex)
                    return _entityTypeSerializer;
                else
                    return base.GetEdmTypeSerializer(edmType);
            }
        }
