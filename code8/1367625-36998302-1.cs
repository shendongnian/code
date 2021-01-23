    static void Main()
    {
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        Bootstrap();
        System.Windows.Forms.Application.Run(GetForm<HomeView, IHomeView>(container));
    }
    private static void Bootstrap()
    {
        // Create the container
        container = new Container();
        // Register types
        // NOTE: We register HomeView as concrete type; not by its interface.
        container.Register<HomeView>(Lifestyle.Singleton);
        // Here we batch-register all presenters with one line of code and
        // since the forms depend on them, they need to be singletons as well.
        container.Register(typeof(IPresenter<>),  AppDomain.CurrentDomain.GetAssemblies(), 
            Lifestyle.Singleton);
        ...
        // Verify the container
        container.Verify();
    }
    private static TForm GetForm<TForm, TView>() where TForm : Form, TView
    {
        var form = container.GetInstance<TForm>();
        container.GetInstance<IPresenter<TView>>().View = form;
        return form;
    }
