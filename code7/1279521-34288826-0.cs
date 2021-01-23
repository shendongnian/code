    class Converter : TypeConverter<Foo, Bar>
    {
        protected override Bar ConvertCore(Foo source)
        {
            if (source.Code != 0)
                return null;
            return new Bar();
        }
    }
    static void Main(string[] args)
        {
            Mapper.CreateMap<Foo, Bar>()
                .ConvertUsing<Converter>();
            
            var bar = Mapper.Map<Bar>(new Foo
            {
                Code = 1
            });
            //bar == null true
        }
