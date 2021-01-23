    public class ClientController : Controller, IRequiresSessionState
    {
    //
    // GET: /
    [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
    [WebMethod(EnableSession = true)]
    public string Index()
    {
         if (System.Web.HttpContext.Current.Session["test-var"] != null)
            return "you are here before " + DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        System.Web.HttpContext.Current.Session["test-var"] = "hi";
        return "you are new";
    }
