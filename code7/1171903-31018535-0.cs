    class MyModel 
    {
        [Required]
        public string Prop1 {get; set;}
        //other validation/UI helpers attributes
        public string Prop1 {get; set;}
    }
     
    [HttpPost]
    public ActionResult Action(MyModel model) 
    { 
        /* body */ 
    }
