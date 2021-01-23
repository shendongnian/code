    namespace Insurance.Controllers
    {
    public class FlexiPAController : Controller
    {
    //
    // GET: /FlexiPA/
    DATABASENAME db = new DATABSENAME (); //ESTABLISHING CONNECTION TO DATABASE
    public ActionResult RegisterFlexiPA()
    {
            using (var dataBase = new DATABASENAME ())
            {
                var model = new RegisterInfoPA()
                {
                    minfo = dataBase.maritalInfoes.ToList(),
                    //IF YOU WISH TO ADD MORE                   
                };
                return View(model);
            }     
    }
