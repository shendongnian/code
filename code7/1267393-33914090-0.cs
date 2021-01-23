    //MyController.cs
    public ActionResult GetSomething(int id)
    {
        var processedResponseTask = _myService.GetAsyn(id)
        //lots of stuff here (1)
        var processedResponseTask.Wait();
        var processedResponse = processedResponseTask.Result;
       
        //lots more stuff here (2)
        return new ContentResult(result);
    }
