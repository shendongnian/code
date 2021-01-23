               if (ModelState.IsValid)
                {
                    if (!IsUserExist(registerUser.Email))
                    { 
                        // bad here
                        //return RedirectToAction("Index", "Task");
                        return new HttpStatusCodeResult(HttpStatusCode.OK); //at least
                    }
                    else
                    {
                      return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "User already exists");
                    }
                }
                else
                {
                   return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Data is incorrect");
                }
