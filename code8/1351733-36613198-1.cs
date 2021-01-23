    > public class HomeController : Controller 
    >{
    >         //
    >         // GET: /Home/
    >         public ActionResult Index()
    >         {
    >             return View();
    >         }
    > 
    >         public ActionResult Products(string name, float price, int qtd)
    >         {
    >             Product product = new Product();
    > 
    >             product.Name = name;
    >             product.Price = price;
    >             product.Qtd = qtd;
    > 
    >             return View();
    >         }
    > }
