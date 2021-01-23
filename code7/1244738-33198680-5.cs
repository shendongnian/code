    public class ClientController : Controller
    {
      public ActionResult Details(long id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return PartialView(client);
        }
    }
