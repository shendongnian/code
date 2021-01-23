    [HttpPost]
        public ActionResult CreatePerson(FormCollection formCollection)
        {
            string name = Request["YourName"].ToString();
            StringBuilder sbRoom = new StringBuilder();
            sbRoom.Append("<b>Amount :</b> " + name + "<br/>");
            return Content(sbRoom.ToString());
        }
