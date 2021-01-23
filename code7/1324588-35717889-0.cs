    public class ContentServiceEventsController : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
          ContentService.Saving += ContentServiceSaving;
        }
        
        private void ContentServiceSaving(IContentService sender, SaveEventArgs<IContent> e)
        {
          // Get the Hotels node
          // Get the Hotel.Children
          // If Hotel.Children.Count == 1, cancel the saving event
          e.Cancel = true;
        }
