    public sealed class HomeViewModelBuilder
    {
      // Example async
      private Task<Carousel> _carouselTask = Task.FromResult<Carousel>(null);
      public HomeViewModelBuilder WithCarousel()
      {
        _carouselTask = _service.GetAsync();
        return this;
      }
      // Example sync
      private int _featuredItems;
      public HomeViewModelBuilder WithFeaturedItems(int featuredItems)
      {
        _featuredItems = featuredItems;
        return this;
      }
      public Task<HomeViewModel> BuildAsync()
      {
        return new HomeViewModel(await _carouselTask, _featuredItems);
      }
    }
