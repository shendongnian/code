    public partial class Window
    {
    ...
        public void Initialize()
        {
        ... that's where the logic goes...
        }
    ...
    }
    Bind<IWindow>().To<Window>()
        .OnActivation(x => x.Initialize());
