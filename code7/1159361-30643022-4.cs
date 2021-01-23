    public class OptionsModel // View Model
    {
        public string ID { get; set; }
        public string User { get; set; }
    }
    
    public ActionResult Index() // Controller
    {
    	OptionsModel options = new OptionsModel();
        options.ID = "server";
    	return View(options);
    }
