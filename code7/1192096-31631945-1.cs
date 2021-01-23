    /// <summary>
    /// This is just an example on how to implement your generic approach using the adapter pattern
    /// </summary>
    public class WebClient
    {
        IEntity ChoferEntity { get; set; }
        IEntity OtraEntity { get; set; }
        public WebClient()
        {
            //You can use as many repositories as you want knowing they all could have different data sources or different store procedures inside same data source
            ChoferEntity.DeleteEntity(1, new Error());
            OtraEntity.DeleteEntity(1, new Error());
        }
    }
