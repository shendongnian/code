    public ActionResult Edit(string EditId)
        {
            if (Session["username"] != null)
            {
                int id;
                //Check try to parse the string into an int if it fails it will return false if it was parsed it will return true
                bool result = Int32.TryParse(EditId, out id);
                if (result)
                {                    
                     //I wouldn't use find unless you're 100% sure that record will always be there.
                     //This will return null if it cannot find your userinfo with that ID
                     UserInfo uinfo = db.UserInfoes.FirstOrDefault(x=>x.ID == id);      
                     //Check for null userInfo    
                return View(uinfo);
            }
            else
            {
                return RedirectToAction("HomeIndex");
            }
        }
