    public class homeController : Controller
    	{
    		//
    		// GET: /home/
    		[HttpGet]
    		public ActionResult Index()
    		{
    			List<Group> lst = new List<Group>();
    			for (var i = 0; i < 5; i++)
    			{
    				lst.Add(new Group()
    				{
    					GroupID = i.ToString(),
    					Name = i.ToString() + " - name",
    					ListGroup = new List<Group>()
    				});
    			}
    			foreach (var g in lst)
    			{
    				for (var i = 0; i < 3; i++)
    				{
    					g.ListGroup.Add(new Group()
    					{
    						GroupID = g.GroupID + i.ToString(),
    						Name = g.Name + i.ToString() + " - subname",
    						ListGroup = new List<Group>()
    					});
    				}
    			}
    			
    			return View(lst);
    		}
    		[HttpPost]
    		public ActionResult Save(List<Group> listModel)
    		{
    			@ViewBag.Success = "Update Suceess";
    			return View(listModel);
    		}
    		public class Group
    		{
    			public string Name { get; set; }
    			public string GroupID { get; set; }
    			public List<Group> ListGroup { get; set; }
    		}
    	}
