        [HttpPost,
        ValidateAntiForgeryToken]
        public ActionResult InlineEdit(int pk, string value, string name)
        {
            //
            // White list to prevent overposting
            string whitelist = "Name,MiddleName,SurName";
            if (!whitelist.Contains(name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, string.Format("Invalid Field {0}", name));
            };
            var user= this._userRep.First(o => o.id== pk);;
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, string.Format("Resource not found"));
            }
            try
            {
                    this.SetPropertyValue(user, name, value);
                    this._userRep.Update(user);
                    this._userRep.SaveChanges();
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, string.Format("{0}: {1}", error.PropertyName, error.ErrorMessage));
            } 
        }
