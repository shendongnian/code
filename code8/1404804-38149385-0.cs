    class YourValueResolver : IValueResolver<YourSourceType, YourBigCollectionType>
    {
        public YourBigCollectionType Resolve(YourSourceType source, YourBigCollectionType destination, ResolutionContext context)
        {
            // here you need your check
            if((bool)context.Items["IncludeBigCollection"])
            {
                // then perform your mapping
                return mappedCollection;
            }
            // else return default or empty
            return default(YourBigCollectionType);
        }
    }
