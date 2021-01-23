    using MyProject.Models;
    public ActionResult FooMeth(MyModel model)
    {
        if (cond == false)
        {
            // If failed, return input data and display error.
            ViewBag.ServerReply = "My Message.";
            return View(model);
        }
        // If successful return to black page.
        return View();
    }
