        /// <summary>
        /// OData Entity Serilizer that omits null properties from the response
        /// </summary>
        public class IngoreNullEntityPropertiesSerializer : ODataResourceSerializer
        {
            public IngoreNullEntityPropertiesSerializer(ODataSerializerProvider provider)
                : base(provider) { }
            /// <summary>
            /// Only return properties that are not null
            /// </summary>
            /// <param name="structuralProperty">The EDM structural property being written.</param>
            /// <param name="resourceContext">The context for the entity instance being written.</param>
            /// <returns>The property be written by the serilizer, a null response will effectively skip this property.</returns>
            public override Microsoft.OData.ODataProperty CreateStructuralProperty(Microsoft.OData.Edm.IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
            {
                var property = base.CreateStructuralProperty(structuralProperty, resourceContext);
                return property.Value != null ? property : null;
            }
        }
