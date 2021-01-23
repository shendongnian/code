    namespace MyNamespace
    {
       class MyViewModel : PropertyChangedBase
       {
          public ObservableCollection<MyItem> MyItems { get; }
    
          public MyViewModel(MyStaticClass myStaticClass)
          {
             MyItems = ConvertMyStaticClassToObservableCollection(myStaticClass);
          }
    
          ObservableCollection<MyItem> ConvertMyStaticClassToObservabeCollection(MyStaticClass myStaticClass)
          {
             ...
          }
       }
    }
