    public class WebPagesController : BaseWebEntityController<WebPage, WebPageModel>
    {
        public WebPagesController(IRepositoryIconIncluded<WebPage> repository)
            : base(repository)
        {
        }
    }
