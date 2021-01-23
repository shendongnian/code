    internal class MyCommandContext
    {
        public string Message { get; set; }
    }
    
    public class MyViewModel : INotifyPropertyChanged
    {
        public ICommand MyCommand { get; private set; }
    
        public string Message { get; set; } // PropertyChanged ommited
        public string OtherProperty { get; set; }
        public ObservableCollection<MyChildViewModel> Childs { get; set; }
    
        public MyViewModel(ICommand myCommand)
        {
            this.MyCommand = myCommand;            
        }
    
           ....
    }
    
    internal interface IMyViewModelCommandManager
    {
        void ExectueMyCommand();
    }
    
    internal class MyViewModelCommandManager : IMyViewModelCommandManager
    {
       private readonly MyCommandContext context;
    
       public MyViewModelCommandManager(MyViewModelCommandContext context)
       {
           this.context = context;
           ....
       }
           
       public ExectueMyCommand()
       {
            MessageBox.Show(this.context.Message);
       }
    }
    internal interface IMyViewModelCommandSynchronizer
    {
        void Initialize();
    }
    internal class MyViewModelCommandSynchronizer : IMyViewModelCommandSynchronizer, IDisposable
    {
         private readOnly MyViewModel viewModel;
         private readOnly MyCommandContext context;
         MyViewModelCommandSynchronizer(MyViewModel viewModel, MyCommandContext context)
         {
             this.viewModel = viewModel;
             this.context = context;
         }
         public void Initialize()
         {
             this.viewModel.PropertyChanged += this.ViewModelOnPropertyChanged;
         }
        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Message")
            {
                 this.context.Message = this.viewModel.Message;
            }
        }
        // Dispose code to deattach the events.
    }
    
    internal class MyViewModelFactory: IMyViewModelFactory
    {
       private readonly IContainerWrapper container;
    
       public MyViewModelFactory(IContainerWrapper container)
       {
           this.container = container;
       }
    
       public MyViewModel Create()
       {
           MyCommandContext context = new MyCommandContext();
    
           IMyViewmodelCommandManager manager = this.container.Resolve<IMyViewmodelCommandManager>(new ResolverOverride[] { new ParameterOverride("context", context) });
    
           ICommand myCommand = new DelegateCommand(manager.ExecuteMyCommand);
    
           MyViewModel viewModel = new MyViewModel(myCommand);
           IMyViewModelCommandSynchronizer synchronizer = this.container.Resolve<IMyViewmodelCommandManager>(new ResolverOverride[] { new ParameterOverride("context", context), new ParameterOverride("viewModel", viewModel) });
           synchronizer.Initialize();
          
           return viewModel;
       }
    }
