    public class ControllerOne : Controller {
        private readonly ModelService _modelService
        //constructor
        public ControllerOne(){
             _modelService= new ModelService ();
        }
        public ActionResult Edit([Bind(Include = "SetValueID,Value,Status,TcSetID,OptionValueID,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] SetValue setValue)
        {
            //Many lines removed for simplicity. all the variables used in the code are assigned.
            if (ModelState.IsValid)
            {
                _modelService.Edit(User, Setvalue);
            }
        }
    //controller 2
    public class HomeController: Controller {
        private readonly ModelService _modelService
        //constructor
        public ControllerOne(){
             _modelService= new ModelService ();
        }
        public ActionResult Index()
        {        
            foreach(var item in db.SetValue.ToList())
            {
                _modelService.Edit(User, item);
            }     
        }
    }
