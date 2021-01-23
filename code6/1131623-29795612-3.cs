    public static class MapperHelper
    {
      public static TTarget ToViewModel<TSource, TTarget>(this TSource source)
      {
        ...
      }
    }
    ...
    var viewModel = model.ToViewModel<MyModel, MyViewModel>();
