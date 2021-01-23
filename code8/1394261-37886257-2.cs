    using EPiServer;
    using EPiServer.Core;
    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;
    using EPiServer.ServiceLocation;
    namespace MySite.Helpers
    {
        [InitializableModule]
        [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
        public class ContentEventInitializer : IInitializableModule
        {
            public void Initialize(InitializationEngine initializationEngine)
            {
                var events = ServiceLocator.Current.GetInstance<IContentEvents>();
                events.CheckedInContent += checkedInContent;
                events.PublishedContent += publishedContent;   
            }
            public void Uninitialize(InitializationEngine initializationEngine)
            {
                var events = ServiceLocator.Current.GetInstance<IContentEvents>();
                events.CheckedInContent -= checkedInContent;
                events.PublishedContent -= publishedContent;   
            }
            /// <summary>
            /// Occurs when a version of a content item has been checked in.
            /// </summary>
            /// <remarks>
            /// This is called after a scheduled publish gets saved.  It's not called after an immediate publish.
            /// Useful for executing custom events following a scheduled publish.  When this event occurs,
            /// you can fetch the publish timestamp from dbo.tblWorkContent.DelayPublishUntil.
            /// Prior to this event the DelayPublishUntil value will be NULL.
            /// </remarks>
            public static void checkedInContent(object sender, ContentEventArgs contentEventArgs)
            {
                // Fetch timestamp from dbo.tblWorkContent.DelayPublishUntil.
                ConnectInfo connectInfo = new ConnectInfo("MyEpiServerDatabase");
                PlannedMaintenanceInfo plannedMaintenanceInfo = new PlannedMaintenanceInfo(ref connectInfo, contentEventArgs.Content.ContentLink.WorkID);
                connectInfo = null;
                // The PlannedMaintenanceInfo method above uses the following SQL query:
                //    string query = string.Format("SELECT URLSegment, DelayPublishUntil FROM tblWorkContent WHERE pkId = {0}", WorkID);
                // TODO: Notify API about this planned maintenance window.
            }
            /// <summary>
            /// Occurs when a content item or a version of a content item has been published.
            /// </summary>
            /// <remarks>
            /// This is called after an immediate publish.  It's not called after a scheduled publish gets saved.
            /// Useful for executing custom events following an immediate publish.
            /// </remarks>
            public void publishedContent(object sender, ContentEventArgs contentEventArgs)
            {
                // TODO: Notify API that an immediate maintenance window has started.
            }
        }
    }
