    public class StringDefaultMaxLengthConvention :  IConceptualModelConvention<EntityType>, IConvention
    {
        private int DefaultMaxLength { get; set; }
        public StringDefaultMaxLengthConvention()
            : this(200)
        {
        }
        public StringDefaultMaxLengthConvention(int defaultMaxLength)
        {
            DefaultMaxLength = defaultMaxLength;
        }
        public void Apply(EntityType item, DbModel model)
        {
            PrimitiveType stringPrimitiveType = PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.String);
            foreach (var property in item.DeclaredProperties.Where(p => p.IsPrimitiveType && p.PrimitiveType == stringPrimitiveType))
            {
                if (!property.MaxLength.HasValue && !property.IsMaxLength)
                {
                    property.MaxLength = DefaultMaxLength;
                }
            }
        }
    }
