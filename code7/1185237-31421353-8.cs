            [HttpPost]
        public ActionResult YourRegisterAction(RegisterViewModel m)
        {
            if (m.FormType == 'A')
                bool success = BL.Server.Instance.SaveMyNewUserToDBTypeA(m.Name, m.Password);
            else if (m.FormType == 'B')
                bool success = BL.Server.Instance.SaveMyNewUserToDBTypeB(m.Name, m.Password);
            return View("ThankYou", success);
        }
