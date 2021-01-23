    public abstract class BaseFacade<T> where T : IBaseWidget
    {
        T Widget { get; set; }
        IBaseConfiguration configuration; //IChildSpecificConfiguration passed in via constructor and assigned to variable
        private void Init()
        {
            Widget = (T)Activator.CreateInstance(typeof());
            Widget.Configure(configuration);
        }
    }
