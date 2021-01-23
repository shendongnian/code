    public class AdminsNotesController : Controller
    {
        private readonly IAdminNoteService _adminNoteService;
        public AdminsNotesController(IAdminNoteService adminNoteService)
        {
            _adminNoteService = adminNoteService;
            FakeDateTimeDelegate = () => DateTime.Now;
        }
        public Func<DateTime> DateTimeDelegate { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminNote adminNote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminNote.AdminKey = this.ControllerContext.HttpContext
                    .User.Identity.GetUserId();
                    adminNote.AdminName = this.ControllerContext.HttpContext
                    .User.Identity.GetUserName();
                    adminNote.CreateDate = DateTimeDelegate();
                    adminNote.ModifiedDate = DateTimeDelegate();
                    adminNote.ObjectState = ObjectState.Added;
                    _adminNoteService.Insert(adminNote);
					
                    return RedirectToAction("UserDetails", "Admin", 
                    new { UserKey = adminNote.UserKey });
                }
            }
            catch (Exception ex)
            {
                ControllerConstants.HandleException(ex);
                ViewBag.PopupMessage(string.Format
                ("We're sorry but an error occurred. {0}", ex.Message));
            }
            return View(adminNote);
        }
	}
	
