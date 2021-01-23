    public class FooViewModel
    {
        public FooViewModel(Parameter parameter, Bar bar, Nice nice) { ...}
    }
    public interface IFooViewModelFactory
    {
        FooViewModel Create(Parameter parameter);
    }
    kernel.Bind<IFooViewModelFactory>().ToFactory();
    FooViewModel instance = kernel.Get<IFooViewModelFactory>()
          .Create(new Parameter("my parameter"));
