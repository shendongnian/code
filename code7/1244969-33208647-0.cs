    public Class FooView : IFooView
    {
       private FooViewModel _viewModel; 
       public FooView()
       {
          _viewModel = new FooViewModel(this);
       }
    }
