    static void OnPhotoCaptured(object obj)
    {
        var args = obj as ImageCaptureNavigationArgs;
        var screen = IOCServiceRegistration<IUnityContainer>.Container.Resolve(typeof(IScreen)) as IScreen; // ReactiveUI dependency kludge. Sigh...
        screen.Router.Navigate.Execute(new PhotoCapturedViewModel(screen, args.Stream));
    }
