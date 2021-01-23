    ViewBag.Status = new List<SelectListItem>(){
         new SelectListItem
         {
            Value = "Yes",
            Text = "Yes",
            Selected = yourFilter.FilterStatus  //If your status is Yes this will be true 
                                                //otherwise false.
         },
         new SelectListItem
         {
            Value = "No",
            Text = "No",
            Selected = yourFilter.FilterStatus  //If your status is No this will be true 
                                                //otherwise false.
         }
    };
