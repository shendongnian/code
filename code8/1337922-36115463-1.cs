    public class TimeSheet
    {
        public DateTime DateSelected { get; set; }
    }
    public ActionResult Create()
    {
        int weekCount = 5;
		List<DateTime> listDates = new List<DateTime>();
		for (int i = 0; i < (weekCount * 7); ++i) //Get next 5 weeks
		{
			listDates.Add(DateTime.Today.AddDays(i));
		}
        ViewData["DateList"] = new SelectList(listDates);		
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "TimeSheetId,WeekCommencing,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours,FridayHours,SaturdayHours,SundayHours,CompletedTimeSheet,PlanId,DateSelected")] TimeSheet timeSheet)
    {
        if (ModelState.IsValid)
        {
            db.TimeSheets.Add(timeSheet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(timeSheet);
    }
    @Html.DropDownListFor(x => x.DateSelected, (SelectList)ViewData["DateList"], new {@class = "form-control"})
    @Html.ValidationMessageFor(x => x.DateSelected, "", new {@class = "text-danger"})
