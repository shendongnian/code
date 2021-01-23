    public class ViewFinder : IViewFinder
    {
        private readonly IEnumerable<IView> availableViews;
        public ViewFinder(IEnumerable<IView> availableViews)
        {
            this.availableViews = availableViews;
        }
        public void LoadView<T>()
        {
            var type = typeof(T);
            foreach (var view in this.availableViews)
            {
                if (view.GetType().IsAssingableFrom(type))
                {
                    view.Show();
                }
            }
        }
