        public ActionResult Edit(string id)
        {
            ...
            returningModel.PLZ = "  ";
            //returningModel.PLZ = null;
        
            bool b = TryValidateModel(returningModel); 
            var modelStateErrors = ModelState.Values.SelectMany(m => m.Errors);
            return View(returningModel);
        }
