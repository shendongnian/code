    public class Someclass : Controller
    {
        private readonly AdminArticleTags m_AdminArticleTags;
        public Someclass(AdminArticleTags aat)
        {
            m_AdminArticleTags = aat;
        }
        public ActionResult Index()
        {
           m_AdminArticleTags.InsertNew(15, 42);
        }
    }
