    class ParentViewModel {
      public ParentViewModel(ChildViewModelFactory childViewModelFactory) {
        _childViewModelFactory = childViewModelFactory;
      }
      public void AddChild() {
        Children.Add(_childViewModelFactory.Create());
      }
      ObservableCollection<ChildViewModel> Children { get; private set; }
     }
    class ChildViewModelFactory {
      public ChildViewModelFactory(/* ChildViewModel dependencies */) {
        // Store dependencies.
      }
      public ChildViewModel Create() {
        return new ChildViewModel(/* Use stored dependencies */);
      }
    }
