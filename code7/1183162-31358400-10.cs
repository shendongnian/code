    public class WebPagesController : BaseWebEntityController<WebPage, WebPageModel>
    {
        public WebPagesController(IRepository<WebPage> repository)
            : base(repository)
        {
        }
    }
