    [TemplateDescriptor(Inherited = true, TemplateTypeCategory = TemplateTypeCategories.HttpHandler)]
    public class ImageResizeHandler : BlobHttpHandler, IRenderTemplate<IContentImage>
    {
        protected override Blob GetBlob(HttpContextBase httpContext)
        {
           //This the implementation from ContentMediaHttpHandler
           var downLoadFileName = httpContext.Request.RequestContext.GetCustomRouteData<string>(DownloadMediaRouter.DownloadSegment);
           if (!string.IsNullOrEmpty(downLoadFileName))
           {
               httpContext.Response.AppendHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", downLoadFileName));
           }
 
           var routeHelper = ServiceLocator.Current.GetInstance<ContentRouteHelper>();
           var binaryStorable = routeHelper.Content as IBinaryStorable;
 
           return binaryStorable != null ? binaryStorable.BinaryData : null;
        }
    }
