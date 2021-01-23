    [RoutePrefix("Groups")] 
    public class GroupController : Controller 
    {
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(Guid id)
        {
            //...
        }
    
        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(GroupEditViewModel model) 
        {
            // ...
        }
    }
