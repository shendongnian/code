    public class HomeController : Controller
    {
        private ImainRepository _helper = null;
    
        public HomeController()
        {
            this._helper = new MainRepository();
        }
 
        public async Task<string> Aboutt()
        {
            string main = await _helper.Top_Five();
            return main;
        }
    }
