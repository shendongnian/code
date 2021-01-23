        HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Compute([Bind(Include = "binaryValue,generator")] CrcModel model)
        {
            if (ModelState.IsValid)
            {
                model.remainder = ComputeFrame(model.binaryValue, model.generator);
                model.signal = model.binaryValue + model.remainder;
                return Json(new { remainder = model.remainder, signal = model.signal });
            }
            else
            {
                Response.StatusCode = 422;
                
                return Json(new { errors = ModelState.Errors });
            }
        }
