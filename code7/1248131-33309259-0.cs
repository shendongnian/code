    public class FooViewModel : ViewModelBase, IFooViewModel
    {
      private IFooService service;
      private ObservableCollection<FooModel> fooCollection;
      public FooViewModel()
      {
         service = FooService(this);
      }
      public void FooCommandMethod(object obj)
      {
         // the responsibility on consuming service outcome is still here!
         this.FooCollection.Add( service.CreateNewModel() );
      }  
    }
    public class FooService : IFooService
    {
      // constructor parameter not needed now
      public FooService()
      {
        this.viewModel = viewModel;   
      }
      public FooModel CreateModel()
      {
         return ...;
      }
    }
