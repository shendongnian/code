    public sealed class HomeViewModelBuilder
    {
      private Task<Carousel> _carouselTask = Task.FromResult<Carousel>(null);
      public HomeViewModelBuilder WithCarousel()
      {
        _carouselTask = _service.GetAsync();
        return this;
      }
      private Task<int> _featuredItemsTask;
      public HomeViewModelBuilder WithFeaturedItems(int featuredItems)
      {
        _featuredItemsTask = _featuredService.GetAsync(featuredItems);
        return this;
      }
      public async Task<HomeViewModel> BuildAsync()
      {
        return new HomeViewModel(await _carouselTask, await _featuredItemsTask);
      }
    }
