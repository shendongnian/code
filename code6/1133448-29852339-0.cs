    public class HomeController : Controller
    {
        private readonly Lazy<IMailService> _mailSrv;
        private readonly Lazy<IDatabaseService> _dbSrv;
        public HomeController(Lazy<IMailService> mailSrv, Lazy<IDatabaseService> dbSrv)
        {
            _mailSrv = mailSrv;
            _dbSrv = dbSrv;
        }
       
        public ActionResult SendMail(string mailAddress)
        {
            _mailSrv.Value.Do(mailAddress);            
        }
        public ActionResult SaveToDatabase(int id, string data)
        {
            _dbSrv.Value.Do(id, data);            
        }
    }
