    public class Someclass : Controller
    {
        private readonly Func<AdminArticleTags> m_AdminArticleTagsFactory;
        public Someclass(Func<AdminArticleTags> factory)
        {
            m_AdminArticleTagsFactory = factory;
        }
        public ActionResult Index()
        {
           AdminArticleTags at = m_AdminArticleTagsFactory();
           at.InsertNew(15, 42);
        }
    }
