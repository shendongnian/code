    public ActionResult Index()
        {
            AddressModel model = new AddressModel();
            model.AvailableUSStates.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            model.AvailableLibraries.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            
            var usstates = _repository.GetAllUSStates();
            foreach (var usstate in usstates)
            {
                model.AvailableUSStates.Add(new SelectListItem()
                {
                    Text = usstate.USStateName,
                    Value = usstate.USStateID.ToString()
                });
            }
            return View(model);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetLibrariesByUSStateID(string USStateID)
        {
            if (string.IsNullOrEmpty(USStateID))
            {
                throw new ArgumentNullException("USStateID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(USStateID, out id);
            var counties = _repository.GetAllLibrariesByUSStateID(id);
            var result = (from s in counties
                          select new
                          {
                              id = s.LibraryID,
                              name = s.LibraryName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(AddressModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                ConfirmModel model2 = new ConfirmModel();
                model2.USStateName = SelectedUSState(model.USStateID.ToString());
                model2.CountyName = SelectedCounty(model.LibraryID.ToString(), model.USStateID.ToString());
                model2.CountyID = model.LibraryID;
                model2.clientID = model.clientId.ToString();
                
                return View("Confirmation", model2);
            }
            return View(model);
        }
        public ActionResult Confirmation(AddressModel model2)
        {
            ConfirmModel model = new ConfirmModel();
            model.USStateName = SelectedUSState(model2.USStateID.ToString());
            model.CountyName = SelectedCounty(model2.LibraryID.ToString(), model2.USStateID.ToString());
            
            var USStateName = model.USStateName;
            return View(model);
        }
        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult Confirmation(ConfirmModel model)
        //{
        //    string USStateName = model.USStateName;
        //    return View();
        //}
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult submitConfirmation(ConfirmModel model)
        {
            if (ModelState.IsValid)
            {
                string usStateName = model.USStateName;
                string countyName = model.CountyName;
                
                DateTime dateTime = DateTime.Now;
                string ipAddress = Request.UserHostAddress;
                string ipAddress2 = Request.ServerVariables["Remote_Addr"];
                string userAgent = Request.UserAgent;
                MailMessage message = new MailMessage();
                message.From = new MailAddress("someone@domain.com");
                message.To.Add(new MailAddress("someoneElse@domain.com"));
                message.Subject = "Subject";
                // You need to use Index because that is the name declared above
                message.Body = "<!DOCTYPE html><head></head><body>" +
                    "<pre>State:\t\t" + usStateName + "</pre>" +
                    "<pre>County:\t\t" + countyName + "</pre>" +
                    "<pre>Remote Name:\t" + ipAddress + "</pre>" +
                    "<pre>Remote User:\t" + userAgent + "</pre>" +
                    "<pre>Date:\t" + dateTime.ToLongDateString() + "</pre>" +
                    "<pre>Time:\t" + dateTime.ToLongTimeString() + "</pre>" +
                    "\n" 
                    "</body>";
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Send(message);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult resetConfirmation()
        {
            return RedirectToAction("Index");
        }
        public string SelectedUSState(string USStateID)
        {
            ViewBag.YouSelected = USStateID.ToString();
            AddressModel model = new AddressModel();
            int id = 0;
            int usStateIDInt = int.Parse(USStateID);
            bool isValid = Int32.TryParse(USStateID, out id);
            var usstates = _repository.GetAllUSStates();
            var state = from s in _repository.GetAllUSStates()
                        where s.USStateID.ToString() == USStateID
                        select s.USStateName;
            var currUSState = state.SingleOrDefault();
            //var currUSStatename = usstates.te
            //model.USStateName = currUSState;
            ViewBag.currUSState = currUSState;
            return currUSState;
        }
        public string SelectedCounty(string CountyID, string USStateID)
        {
            AddressModel model = new AddressModel();
            int id = 0;
            int countyIDInt = int.Parse(CountyID);
            bool isValid = Int32.TryParse(CountyID, out id);
            int usStateIDInt = int.Parse(USStateID);
            var counties = _repository.GetAllLibrariesByUSStateID(usStateIDInt);
            var county = from s in counties
                         where s.LibraryID.ToString() == CountyID
                         select s.LibraryName;
            var currCounty = county.SingleOrDefault();
            ViewBag.currCounty = currCounty;
            return currCounty;
        }
