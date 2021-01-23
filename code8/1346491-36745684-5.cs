    CompositionRoot.Initialize(new DependencyModule());
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    var appCtrl = CompositionRoot.Resolve<ApplicationShellController>()
    Application.Run(appCtrl.GetView());
