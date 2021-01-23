        public ActionResult MyAction(OrderDTO order)
        {
           // Validate your fields against your possible sources (Request.Form,QueryString, etc)
           if(HttpContext.Current.Request.Form["Ammount"] == null)
           {
               throw new YourCustomExceptionForValidationErrors("Ammount was not sent");
           }
           // Do your stuff
        }
