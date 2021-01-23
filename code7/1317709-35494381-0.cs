        [HttpPost]
        public ActionResult form(form_Data form_data, IEnumerable<string> commPref)
        {
            if (ModelState.IsValid) // Perform DB Actions
            {
                // Checkbox Object Loop - commPref field
                // Loop through each string array element of form field to build resulting field value
                if (form_data.commPref != null)
                {
                    //Code to make comma-delimited list of Checkbox choices
                    //form_data.commPref = string.Join(",", commPref);
                    //Wraps each Checkbox choice in pipes (|) to strictly define choice for display on form
                    form_data.commPref = "|";
                    foreach (var item in commPref)
                    {
                        form_data.commPref += item;
                        form_data.commPref += "|";
                    }
                }
                if (form_data.dataID != 0) // Edit Record
                {
                    db.Entry(form_data).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { msg = 2 });
                }
                else // Create Record
                {
                    db.formapp_Data.Add(form_data);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { msg = 1 });
                }
            }
            else // Show Errors
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View();
            }
        }
