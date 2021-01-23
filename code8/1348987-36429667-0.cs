    List<SelectListItem> lstAssignments = new List<SelectListItem>();
            using(var context = new fakeconnectionstring())
            {
                List<table1> lstActivity = context.table1.Where(x => x.deleted == false).ToList();
                foreach(table1 activity in lstActivity)
                {
                    SelectListGroup lstGroupCategories = new SelectListGroup() { Name = activity.subcategory };
                    SelectListItem item = new SelectListItem() { Text = activity.text, Value = activity.ID.ToString(), Group = lstGroupCategories };
                }
            }
