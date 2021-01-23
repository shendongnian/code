    public ActionResult New()
    {
        MyViewModel myViewModel = new MyViewModel ();
        myViewModel.OfficeAddressCountry = default value; 
        //Pass it to the view using the `ActionResult`
        return ActionResult( myViewModel);
    }
