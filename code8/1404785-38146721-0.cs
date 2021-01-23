    public class SomeController : Controller {
        public SomeController(LSF1617Entities dbContext)
        {
            _dbContext = dbContext;
        }
    
        public ActionResult Index()
        {
            var model = (from people in context.People join hobbies in context.Hobby on people.Hobby_ID equals hobbies.ID
                        select new PeopleHobbyView { ID = people.ID, Forename = people.Forename, Surname = people.Surname, Hobby_Name = hobbies.Hobby_Name}
                    ).ToList();
    
            return View(model);
        }
