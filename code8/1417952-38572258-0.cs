    public class MyConverter<TSource, TDest> 
        : ITypeConverter<IEnumerable<TSource>, MyCustomCollectionType<TDest>> {
        public MyCustomCollectionType<TDest> Convert(
            IEnumerable<TSource> source, 
            MyCustomCollectionType<TDest> dest, 
            ResolutionContext context) {
            // you now have the known types of TSource and TDest
            // you're probably creating the dest collection
            dest = dest ?? new MyCustomCollectionType<TDest>();
            // You're probably mapping the contents
            foreach (var sourceItem in source) {
                dest.Add(context.Mapper.Map<TSource, TDest>(sourceItem));
            }
            //then returning that collection
            return dest;
        }
    }
