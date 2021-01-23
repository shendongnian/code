    [HttpGet]
        public ActionResult BookFlight()
        {
            // Check if the user is logged in, if not redirect to log in page
            if (User.Identity.IsAuthenticated)
            {
                SetDepartureandArrival();
                return View();
            }
            else
                return RedirectToAction("../User/LogIn");
        }
        public void SetDepartureandArrival()
        {
                Departures.Add(new SelectListItem { Text = "-Select-", Value = "0" });
                Departures.Add(new SelectListItem { Text = "London", Value = "London" });
                Departures.Add(new SelectListItem { Text = "Manchester", Value = "Manchester" });
                Departures.Add(new SelectListItem { Text = "Edinburgh", Value = "Edinburgh" });
                Departures.Add(new SelectListItem { Text = "East Midlands", Value = "East Midlands" });
                Departures.Add(new SelectListItem { Text = "Bristol", Value = "Bristol" });
                ViewData["departures"] = Departures;
            Arrivals.Add(new SelectListItem { Text = "-Select-  ", Value = "0" });
            Arrivals.Add(new SelectListItem { Text = "Paris", Value = "Paris" });
            Arrivals.Add(new SelectListItem { Text = "Barcelona", Value = "Barcelona" });
            Arrivals.Add(new SelectListItem { Text = "Madrid", Value = "Madrid" });
            Arrivals.Add(new SelectListItem { Text = "Amsterdam", Value = "Amsterdam" });
            Arrivals.Add(new SelectListItem { Text = "Prague", Value = "Prague" });
            Arrivals.Add(new SelectListItem { Text = "Nice", Value = "Nice" });
            Arrivals.Add(new SelectListItem { Text = "Milan", Value = "Milan" });
            Arrivals.Add(new SelectListItem { Text = "Geneva", Value = "Geneva" });
            Arrivals.Add(new SelectListItem { Text = "Rome", Value = "Rome" });
            ViewData["arrivals"] = Arrivals;
        }
        [HttpPost]
        public ActionResult BookFlight(FlightDetailsMD flights, FormCollection form)
        {
            Random rand = new Random();
            Random rand2 = new Random();
            if (ModelState.IsValid)
            {
                var departureVal = form["departures"];
                var arrivalVal = form["arrivals"];
                using (var db = new FlightDetailsEntities())
                {
                    var user = db.FlightDetails.Create();
                    user.Id = rand.Next(100000, 199999) + rand2.Next(100000, 199999);
                    user.Departure = departureVal;
                    user.Arrivals = arrivalVal;
                    user.DepartureDate = flights.DepartureDate;
                    user.ReturnDate = flights.ReturnDate;
                    db.FlightDetails.Add(user);
                    db.SaveChanges();
                    MailMessage mail = new MailMessage();
                    mail.To.Add(User.Identity.Name);
                    mail.From = new MailAddress(User.Identity.Name);
                    mail.Subject = "Booking Confirmation";
                    string Body = "Email from: <i>insert company name</i><br><br> Your booking is confirmed! You are going to " + user.Arrivals +
                        " on " + string.Format("{0:dd/MM/yyyy}", user.DepartureDate) + " and returning to " + user.Departure + " on " + string.Format("{0:dd/MM/yyyy}", user.ReturnDate) +
                        ".<br> Thank you for booking with us and we hope you have a nice time!" + "<br><h2>Reference #" + user.Id + "</h2>";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    //SmtpClient client = new SmtpClient();
                    using (SmtpClient client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(User.Identity.Name, "RecurveBow");
                        client.Host = "smtp.live.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Send(mail);
                    }
               
                    return RedirectToAction("BookingDetails", "Home");
                }
            }
             SetDepartureandArrival();
            return View();
        }
