    // ~/Controllers/SomeController.cs
    public class SomeController: Controller {
        // This would be the landing view of a given controller
        public ActionResult Index() {
            // for this view model I have basically typed the things that 
            // are a concern of Index, like page title and other things
            // but nothing related to the view models that I will be
            // updating or inserting
            var viewModel = somePrivateMethodToBuildMyViewModel();
            return View(viewModel);
        }
    
        public PartialViewResult SomeInfo() {
            // this is technically a fresh instance with normalized
            // or localized default data that I will be sending 
            // when the index requests this partial view
            var someViewModel = somePrivateMethodToBuildSomeViewModel();
            return PartialView(someViewModel);
        }
        
        [HttpPost]
        public PartialViewResult AddSomeInfo(SomeViewModel viewModel) {
            // this is where I am checking if my view model is alright
            // and then the "issue" will occur
            if (!ModelState.IsValid) {
                // ... handle  
            } else { 
                // I was doing "normal stuff" like 
                // translating view model to an entity (let's call it model)
                // committing changes with some ORM and get and id and timestamp back
                // and naturally assign these values to the view model 
               
                viewModel.Id = model.id;
                viewModel.createdOn = model.created_on; 
            }
            // then return the same view and same model **types** of the request
            return PartialView("SomeInfo", viewModel);
        }
    }
