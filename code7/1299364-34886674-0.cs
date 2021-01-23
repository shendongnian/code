    [HttpPost]
    public ActionResult sendProp(Category pModel) {
        //If you put a breakpoint here, pModel.statename will have the value from getlgass().
        string state = pModel.statename;
        return this.Json("success");
    }
