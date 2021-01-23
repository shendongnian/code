        public class HomeController : Controller
        {
            public HomeController(IContainer injectedContainer)
            {
                var myPet = injectedContainer.GetInstance<IPet>("B");
                string name = myPet.Name; // Returns "CatB"
    
