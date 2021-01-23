    public class HomeController : Controller
    {
        private ImainRepository _helper = null;
    
        public HomeController()
        {
            this._helper = new MainRepository();
        }
 
        public async Task<string> Aboutt()
        {
            object main = (await _helper.Top_Five()) ?? null;
            return main != null ? main.ToString() : null;
        }
    }
