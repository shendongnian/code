    public class MyController : Controller
    {
    private static List<Client> c1 = new List<Client>();
    // GET: 
    public ActionResult Index()
    {
        ....
        // you can access c1 here, change it, etc
        c1.Add(client);
        ....
