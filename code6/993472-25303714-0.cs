    public static class HomeViewModelBuilderExtension
    {
        public static Task<HomeViewModelBuilder> WithCarousel(this HomeViewModelBuilder antecedent)
        {
            return WithCarousel(Task.FromResult(antecedent));
        }
        public static async Task<HomeViewModelBuilder> WithCarousel(this Task<HomeViewModelBuilder> antecedent)
        {
            var builder = await antecedent;
            var carouselItems = await builder.Service.GetAsync();
            builder.ViewModel.Carousel = carouselItems;
            return builder;
        }
        public static Task<HomeViewModelBuilder> WithFeaturedItems(this HomeViewModelBuilder antecedent, int number)
        {
            return WithFeaturedItems(Task.FromResult(antecedent), number);
        }
        public static async Task<HomeViewModelBuilder> WithFeaturedItems(this Task<HomeViewModelBuilder> antecedent, int number)
        {
            var builder = await antecedent;
            builder.ViewModel.FeaturedItems = number;
            return builder;
        }
    }
