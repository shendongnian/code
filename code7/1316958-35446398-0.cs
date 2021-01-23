    public interface IFormatter
    {
        string Format(Model model);
    }
    public interface IFormatterA : IFormatter
    {
    }
    public interface IFormatterB : IFormatter
    {
    }
    public interface IFormatterFactory
    {
        IFormatter Create();
    }
    public class FormatterFactory : IFormatterFactory
    {
        private IUnityContainer _container;
        public FormatterFactory(IUnityContainer container)
        {
            _container = container;
        }
        public IFormatter Create()
        {
            if (Monday)
                return _container.Resolve<IFormatterA>();
            if(Tuesday)
                return _container.Resolve<IFormatterB>();
        }
    }
