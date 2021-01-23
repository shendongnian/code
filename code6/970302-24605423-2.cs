    [HttpPost]
            public ActionResult TestPost(VmSysTestModel obj)
            {
    
                //Start Validation     From start to end you can call this code everywhere you want  , this will work like server side valdiatin
                //Instead of ModelState.IsValid you will call your fluent validator
                var testValidator = new VmSysTestValidator();
                var validationResult = testValidator.Validate(obj);
                if (validationResult.IsValid)
                {
    
                }
                else
                {
                   
                }
                //End valdiation 
            }
