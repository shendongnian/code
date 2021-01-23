     class Program
            {
                static void Main(string[] args)
                {
                    IApplicationController applicationController = new ApplicationController(new ServicesContainerAdapter());
        
                    applicationController
        
        
                        //RegisterView
                        .RegisterView<IMainView, MainForm>()
                        .RegisterView<IChildView, ChildForm>()
        
        
                        //RegisterPresenter
                        .RegisterPresenter<IMainPresenter, MainPresenter>()
                        .RegisterPresenter<IChildPresenter, ChildPresenter>()
        
        
                        //RegisterController
                        .RegisterController<IMainControl, MainControl>()
                        .RegisterController<IChildControl, ChildControl>();
        
        
        
                    IMainPresenter mainPresenter = applicationController.Resolve<IMainPresenter>();
                    mainPresenter.Init();
        
                    Application.Run((Form)mainPresenter.FormObject);
                }
           }
