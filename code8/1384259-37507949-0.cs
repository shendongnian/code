    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var p1 = new Projection() { Id = 1, DirectCostOfOperation = "111", Turnover = "100" };
            var p2 = new Projection() { Id = 2, DirectCostOfOperation = "222", Turnover = "200" };
            var p3 = new Projection() { Id = 3, DirectCostOfOperation = "333", Turnover = "300" };
            var p4 = new Projection() { Id = 4, DirectCostOfOperation = "444", Turnover = "400" };
            var p5 = new Projection() { Id = 5, DirectCostOfOperation = "555", Turnover = "500" };
            Step4 step = new Step4();
            step.Projections = new List<Projection> { p1, p2, p3, p4, p5 };
            return View(step);
        }
    }
    [Serializable]
    public class Step4
    {
        public IList<Projection> Projections { get; set; }
    }
    public class Projection : IYear
    {
        public int Id { get; set; }
        public string Turnover { get; set; }
        public string DirectCostOfOperation { get; set; }
    }
    public interface IYear
    {
        int Id { get; set; }
        string Turnover { get; set; }
        string DirectCostOfOperation { get; set; }
    }
