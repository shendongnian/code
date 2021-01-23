     public HttpResponseMessage GetModelStateErrors()
        {
            //return Request.CreateResponse(HttpStatusCode.OK, new Product());
            ModelState.AddModelError("EmployeeId", "Employee Id is required.");
            ModelState.AddModelError("EmployeeId", "Employee Id should be integer");
            ModelState.AddModelError("Address", "Address is required");
            ModelState.AddModelError("Email", "Email is required");
            ModelState.AddModelError("Email", "Invalid Email provided.");
            var error = new {
                message = "The request is invalid.",
                error = ModelState.Values.SelectMany(e=> e.Errors.Select(er=>er.ErrorMessage))
            };
            return Request.CreateResponse(HttpStatusCode.BadRequest, error);
        }
