        [HttpPost]
        public ActionResult Register(Model objModel )
        {
            foreach (string Key in ModelState.Keys)
                    {
                        if ((Key.Equals("Email")) || (Key.Equals("Password")))
                        {
                            ModelState[Key].Errors.Clear();
                        }
                    }
                    if (ModelState.IsValid)
                    { 
                           //Do the work
                    }
       }
