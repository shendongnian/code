    public class ContentServiceEventsController : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
          ContentService.Saving += ContentServiceSaving;
        }
        
        private void ContentServiceSaving(IContentService sender, SaveEventArgs<IContent> e)
        {
          switch (e.Entity.ContentType.Alias)
          {
            case "RoomsDocumentTypeAlias":
            case "FacilitiesDocumentTypeAlias":
            // Do your logic to detect if your Hotel node "Hilton eilat queen of sheba" 
            // already contains either a Rooms node or a Facilities node underneath.
            // If so, cancel the creation of the event of a new one.
            e.Cancel = true;
            break;
            default:
                   break;
          }
        }
