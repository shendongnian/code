    public class SecureEnableQueryAttribute : EnableQueryAttribute
    {
        public List<Type> RestrictedTypes => new List<Type>() { typeof(MyLib.Entities.Order) }; 
        public override void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
        {
            List<IEdmType> expandedTypes = queryOptions.GetAllExpandedEdmTypes();
            List<string> expandedTypeNames = new List<string>();
            //For single navigation properties
            expandedTypeNames.AddRange(expandedTypes.OfType<EdmEntityType>().Select(entityType => entityType.FullTypeName()));
            //For collection navigation properties
            expandedTypeNames.AddRange(expandedTypes.OfType<EdmCollectionType>().Select(collectionType => collectionType.ElementType.Definition.FullTypeName())); 
            
            //Simply a blanket "If it exists" statement. Feel free to be as granular as you like with how you restrict the types. 
            bool restrictedTypeExists =  RestrictedTypes.Select(rt => rt.FullName).Any(rtName => expandedTypeNames.Contains(rtName));
            if (restrictedTypeExists)
            {
                throw new InvalidOperationException();
            }
            base.ValidateQuery(request, queryOptions);
        }
        
    }
