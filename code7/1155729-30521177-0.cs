    You can use annotations [Required] attribute to make it mandatory field.
    If JavaScript is enabled,and there is no user input in mandatory field,you will see control will not pass to controller action.
    In Case JavaScript is disabled,control will pass to controller action with **ModelState.IsValid** value will be false.
    
    Server side code should be like this:
    
    [HttpPost]
        public ActionResult Index (string xmasText)
        {
           if (ModelState.IsValid)//rather than check of whitespace
            {
                 // ....
            }
        }
