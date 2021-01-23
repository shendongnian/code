    public class CustomFilterApplicationModelProvider : IApplicationModelProvider
    {
        public int Order
        {
            get { return 0; }
        }
        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            //Do nothing
        }
        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            this.ReplaceFilters(context.Result.Filters);
            foreach(var controller in context.Result.Controllers)
            {
                this.ReplaceFilters(controller.Filters);
                foreach (var action in controller.Actions)
                {
                    this.ReplaceFilters(action.Filters);
                }
            }
        }
        private void ReplaceFilters(IList<IFilterMetadata> filters)
        {
            var authorizationFilters = filters.OfType<AuthorizeFilter>().ToList();
            foreach (var filter in authorizationFilters)
            {
                filters.Remove(filter);
                filters.Add(new CustomJsonAuthorizationFilter(filter));
            }
        }
    }
