    public class ReportController : Controller
    {
        public ReportController([Named("replication")]IUOW replication)
        {
        }
    }
    public class NormalController : Controller
    {
        public NormalController([Named("uow")]IUOW uow)
        {
        }
    }
