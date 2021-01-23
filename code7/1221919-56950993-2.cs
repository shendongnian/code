       public class AdminEventsController : Controller
       {
        [HttpGet]
        public ActionResult addEvent()
        {   
            ////ComboBox Country
            List<SelectListItem> lst = new List<SelectListItem>();
            MngEvent events = new MngEvent();
            DataTable dt1 = events.ShowEvent();
            for (int i = 0; i <= dt1.Rows.Count; i++)
            {
                lst.Add(new SelectListItem { Text = dt1.Rows[i]["ConfrenceCountry"].ToString(), Value = dt1.Rows[i]["ConfrenceID"].ToString() });
            }
            ViewData["dropdownCountry"] = lst;
            return View();
        }
     }
