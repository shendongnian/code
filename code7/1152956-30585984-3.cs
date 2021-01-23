    // ~/Controllers/SomeController.cs
    public class SomeController: Controller {
         
        // ...        
        [HttpPost]
        public PartialViewResult AddSomeInfo(SomeViewModel viewModel) { 
            if (!ModelState.IsValid) {
                // ... handle  
            } else {  
                // Included this line for valid model state handling
                ModelState.Clear();
                // then persist, etc
                // then change view model
                viewModel.Id = model.id;
                viewModel.createdOn = model.created_on; 
            }
            // then returning the view model to the same partial should now work
            return PartialView("SomeInfo", viewModel);
        }
    }
