    public static class MapperHelper<TSource, TTarget>
    {
      public static TTarget ToViewModel(this TSource source)
      {
        ...
      }
    }
    ...
    // this is no problem if we invoke our method like a
    // static method:-
    var viewModel = MapperHelper<MyModel, MyViewModel>.ToViewModel(model);
    // but if we use the extension method syntax then how
    // does the compiler know what TSource and TTarget are?:-
    var viewModel = model.ToViewModel();
