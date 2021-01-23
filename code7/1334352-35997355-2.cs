    namespace MyNamespace
    {
        public static class ListHelper
        {
            public static IEnumerable<SelectListItem> CreateTimeSlotsList()
            {
                List<SelectListItem> l = new List<SelectListItem>();
                l.Add(new SelectListItem { Text = "Tues Mar. 15, 09:40am", Value = "1" });
                l.Add(new SelectListItem { Text = "Tues Mar. 15, 11:00am", Value = "2" });
                l.Add(new SelectListItem { Text = "Tues Mar. 15, 1:10pm", Value = "3" });
                l.Add(new SelectListItem { Text = "Tues Mar. 15, 2:10pm", Value = "4" });
                l.Add(new SelectListItem { Text = "Tues Mar. 15, 3:30pm", Value = "5" });            
                l.Add(new SelectListItem { Text = "Wed  Mar. 16, 8:30am", Value = "6" });
                l.Add(new SelectListItem { Text = "Wed Mar. 16, 9:30am", Value = "7" });
                l.Add(new SelectListItem { Text = "Wed Mar. 16, 11:00am", Value = "8" });
                l.Add(new SelectListItem { Text = "Wed Mar. 16, 1:10pm", Value = "9" });
                l.Add(new SelectListItem { Text = "Wed Mar. 16, 2:10pm", Value = "10" });            
                return l;
            }
        }
    }
