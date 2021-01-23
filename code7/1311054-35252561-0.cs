    class TestResource
    {
        public int Testnumber { get; set; }
        public string Testtext { get; set; }
    }
    class TestDestination
    {
        public string Testtext { get; set; }
    }
    class Program
    {
        // equivalent to what you tried to do - needs explicit generic parameters on call
        static N mapAnything<T, K, M, N>(M model, N newModel)
        {
            var mapconfiguration = new MapperConfiguration(cfg => cfg.CreateMap<T, K>());
            var mapper = mapconfiguration.CreateMapper();
            var result = mapper.Map<M, N>(model, newModel);
            return result;
        }
        // variant for object mapping, where generics can be implicitely inferred
        static N mapObject<M, N>(M model, N newModel)
        {
            var mapconfiguration = new MapperConfiguration(cfg => cfg.CreateMap<M, N>());
            var mapper = mapconfiguration.CreateMapper();
            var result = mapper.Map<M, N>(model, newModel);
            return result;
        }
        // variant for lists, where generics can be implicitely inferred
        static ICollection<N> mapCollection<M, N>(IEnumerable<M> model, ICollection<N> newModel)
        {
            var mapconfiguration = new MapperConfiguration(cfg => cfg.CreateMap<M, N>());
            var mapper = mapconfiguration.CreateMapper();
            var result = mapper.Map<IEnumerable<M>, ICollection<N>>(model, newModel);
            return result;
        }
        static void Main(string[] args)
        {
            var res1 = new TestResource() { Testnumber = 1, Testtext = "a" };
            var res2 = new List<TestResource>();
            for (int i = 0; i < 10; i++)
            {
                res2.Add(new TestResource() { Testnumber = i, Testtext = "test: " + i });
            }
            var mapped1 = mapObject(res1, new TestDestination());
            var mapped2 = mapCollection(res2, new HashSet<TestDestination>());
            var mapped3 = mapAnything<TestResource, TestDestination, TestResource, TestDestination>(res1, new TestDestination());
            var mapped4 = mapAnything<TestResource, TestDestination, IEnumerable<TestResource>, List<TestDestination>>(res2, new List<TestDestination>());
        }
    }
