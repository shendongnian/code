    public class ExpiryDateEvent : IApplicationEventHandler 
    {
        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Published += ContentService_Published;
        }
        void ContentService_Published(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            var entity = e.Entity;
            if (entity.HasProperty("expiryDate") && e.entity.ExpireDate.HasValue)
            {
                 entity.SetValue("expiryDate", e.Entity.ExpireDate.Value);
                 sender.Save(entity);
            }
        }
    }
