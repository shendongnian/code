    public class DropBoxController : Controller
    {
       
        private readonly ICommandChannel _commandChannel;
        private readonly IQueryChannel _queryChannel;
        private readonly UserModel _user;
        public DropBoxController(ICommandChannel commandChannel, IQueryChannel queryChannel, UserModel user)
        {
            _commandChannel = commandChannel;
            _queryChannel = queryChannel;
            _user = user;
        }
        public ActionResult Index()
        {
            var con = new ConnectionManager();
            var dropclient = con.Connect();
            var callbackurl = Request.Url.Scheme + "://" + Request.Url.Authority + "/DropBox/Callback";
            var url = con.GetConnectUrl(dropclient, callbackurl);
            _commandChannel.Execute(new SaveDropBoxTempSecurityCommand { AuthToken = dropclient.UserLogin.Token, Token = dropclient.UserLogin.Token, Secret = dropclient.UserLogin.Secret });
            return Redirect(url);
            //return View(new UrlModel {Url = url});
        }
        [HttpGet]
        public ActionResult Callback(string oauth_token)
        {
            TokenAndSecretModel model = _queryChannel.Execute(new GetDropBoxTempTokenQuery{Token = oauth_token});
            var con = new ConnectionManager();
            var login = con.GetAccessToken(model.Token, model.Secret);
            _commandChannel.Execute(new SaveDropBoxLoginCommand{AuthToken = oauth_token, Login = login});
            return View();
        }
    }
    public class UrlModel
    {
        public string Url { get; set; }
    }
