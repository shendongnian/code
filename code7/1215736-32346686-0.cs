    public class ModelToViewModelMapper
    {
        public ViewModel Map(Model b)
        {
            return new ViewModel { Foo = b.Foo.ToString() };
        }
    }
