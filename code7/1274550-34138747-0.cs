    public class AppointmentViewModel
    {
        public int appointment_id { get; set; }
        public string appointment_description { get; set; }    
        public StudentViewModel student { get; set; }
        public IEnumerable<SelectListItem> ScheduleSelectListItems { get; set; };
        public int SelectedScheduleId { get; set; }
    }
    public ActionResult Book()
    {
        var items = db.schedules.Select(sched => new SelectListItem { Text = string.Format("{0} - {1}", sched.sched_stime, sched.sched_etime), Value = sched.Id });
    
        var model = new AppointmentViewModel { ScheduleSelectListItems = items };
        return View(model);
    }
