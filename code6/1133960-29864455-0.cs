    public static List<TDestination> ToEntity<TDestination>(this List<object> OBJSource)
        {
            List<TDestination> destination = new List<TDestination>();//Handling the null destination
            foreach (object source in OBJSource)
                destination.Add(AutoMapper.Mapper.DynamicMap<TDestination>(source));
            return destination;
        }
