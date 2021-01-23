    public ActionResult Settings(string id)
    {
        var controller = new FirstController(); //argh
        var result = controller.GetUserData(id);
    }
