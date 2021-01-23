    public static class AnimalFactory
    {
        public static Animal Create<T>(T source)
            where T : class
        {
            Mapper.CreateMap<T, Animal>();
            return Mapper.Map<Animal>(source);
        }
    }
