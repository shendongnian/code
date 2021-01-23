    public static class MapperHelper<TSource, TTarget>
    {
      public static TTarget ToViewModel(this TSource source)
      {
        ...
      }
    }
    ...
    // How does the compiler know what TSource/TTarget are?
    var viewModel = model.ToViewModel();
