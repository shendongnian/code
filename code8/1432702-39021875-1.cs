        public ActionResult Submit(FormCollection fm)
        {
            string Allpayments = Request.Form["app1"];
            string Callpay = Request.Form["app2"];
            string ThinGateway = Request.Form["app3"];
            string IVR = Request.Form["app4"];
            string TextPay = Request.Form["app5"];
            string SMSEngine = Request.Form["app6"];
            string AndroidMobileApp = Request.Form["app7"];
            string IOSMobileApp = Request.Form["app8"];
            string WindowsMobileApp = Request.Form["app9"];
            return View();
        }
