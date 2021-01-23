      public class AdModel : RenderModel
        {
            public string Parent{ get; set; }
            public string Child { get; set; }
             
            public AdModel () : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
            {
            }
        }
