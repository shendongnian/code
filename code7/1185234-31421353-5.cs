        [HttpPost]
        public ActionResult YourRegisterAction(char formType, string name, string password)
        {
            if (formType == 'A')
                bool success = BL.Server.Instance.SaveMyNewUserToDBTypeA(name, password);
            else if (formType == 'B')
                bool success = BL.Server.Instance.SaveMyNewUserToDBTypeB(name, password);
            return View("ThankYou", success);
        }
