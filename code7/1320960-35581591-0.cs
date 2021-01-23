    public ActionResult myMethod(string reference, long quantity, ControllerContext context)
    {
        wsResponse = callWS(reference, quantity);
        if (GenericUtils.isError(wsResponse))
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Something failed");
        }
        else
        {
            return Json(response);
        }
    }
