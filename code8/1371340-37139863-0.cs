        public ActionResult Export(string PatientName, string BirthDate, string Gender, string PatientType)
        {
            ViewBag.PatientName = PatientName ?? "";
            ViewBag.BirthDate = BirthDate ?? "";
            ViewBag.Gender = Gender ?? "";
            ViewBag.PatientType = PatientType ?? "";
            var predicate = PredicateBuilder.True<Patient>();
            if (!string.IsNullOrEmpty(PatientName))
            {
                predicate = predicate.And(i => i.FirstName.ToLower().StartsWith(PatientName) || i.LastName.ToLower().StartsWith(PatientName));
            }
            if (!string.IsNullOrEmpty(Gender))
            {
                int gender;
                Int32.TryParse(Gender, out gender);
                predicate = predicate.And(i => i.Gender == gender);
            }
            if (!string.IsNullOrEmpty(PatientType))
            {
                int type;
                Int32.TryParse(PatientType, out type);
                predicate = predicate.And(i => i.PatientType == type);
            }
            if (!string.IsNullOrEmpty(BirthDate))
            {
                DateTime dob;
                DateTime.TryParse(BirthDate, out dob);
                predicate = predicate.And(i => EntityFunctions.TruncateTime(i.BirthDate) == EntityFunctions.TruncateTime(dob));
            }
            var patients = db.Patients.Where(predicate).Select(i => i).Include(p => p.DropDownOption).Include(p => p.DropDownOption1);
            GridView gv = new GridView();
            gv.DataSource = patients.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=IbiliPasswords.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
