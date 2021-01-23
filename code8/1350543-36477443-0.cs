       [HttpPost]
        public ActionResult GetEmpNo(string value)
        {
            string str = value;
            List<SelectListItem> items = new List<SelectListItem>();
            if (value == "Representative")
            {
                // query the tb_RepDetails table and get values.
                items = context.tb_RepDetails.Select(c => new SelectListItem() { Text = c.RepId }).ToList();
            }
            else if (value == "Agent")
            {
                //query the tb_AgentDetails table and get values.
                items = context.tb_AgentDetails.Select(c => new SelectListItem() { Text = c.AgentId }).ToList();
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }
