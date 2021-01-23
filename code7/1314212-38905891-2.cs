    public class ProductPropertyVisitor : NoopPropertyVisitor
    {
        public override void Visit(IStringProperty type, PropertyInfo propertyInfo, ElasticsearchPropertyAttributeBase attribute)
        {
            base.Visit(type, propertyInfo, attribute);
    
            var wsaf = propertyInfo.GetCustomAttribute<WantsStandardAnalysisField>();
            if (wsaf != null)
            {
                type.Index = FieldIndexOption.NotAnalyzed;
                type.Fields = new Properties
                {
                    {
                        "standard",
                        new StringProperty
                        {
                            Index = FieldIndexOption.Analyzed,
                            Analyzer = "standard"
                        }
                    }
                };
            }
        }
    }
