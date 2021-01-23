    public static class MapperHelper<TSource, TTarget>
    {
      public static TTarget ToViewModel(this TSource source)
      {
        ...
      }
    }
    ...
    var viewModel = model.ToViewModel(); // How does the compiler know what types you want?
