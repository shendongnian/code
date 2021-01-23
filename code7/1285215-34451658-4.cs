    [HttpPost]
    public ActionResult Index(MyModel model)
    {
        char inputType = model.SelectedValue[0];
        int id = int.Parse(model.SelectedValue.Substring(1));
        
        if(inputType == 'C')
        {
            // Insert City id.
        }
        else
        {
            // Insert Location id.
        }
    }
