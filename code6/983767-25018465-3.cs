    [HttpPost]
    public ActionResult MyAction(Model myModel)
    {
        foreach(var item in myModel)
        {
            if(item.Checked)
            {
                // do something
            }
        }
    }
