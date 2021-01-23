     public ActionResult UpdateDateOfBirth(ModelClass model)
        {
                if (ModelState.IsValid)
                {
                    // your logic
                }
                AddErrors(ModelState);
                return View();
        }
        
        // in my case i have to be add in viewbag
        private void AddErrors(ModelStateDictionary result)
        {
            ViewBag.ErrorMessages = result;
            //foreach (KeyValuePair<string,System.Web.Mvc.ModelState> error in result)
            //{              
            //    //ModelState.AddModelError(error.Key,error.Value.Errors[0].ErrorMessage);
            //}
        }
       // and you can add the validation message on 
       public class ModelClass
       {
        [StringLength(100, ErrorMessage = "Not a valid date of birth"]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth{ get; set; }
       }
