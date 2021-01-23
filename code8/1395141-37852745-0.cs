    // Order/{location}/{orderId}
    public ActionResult Step1(string location, int? orderId)
    // Order/{location}/{category}/{orderId}
    public ActionResult Step2(string location, string category, int? orderId)
    // Order/{location}/{category}/{item}/{id}/{orderId}
    public ActionResult Step3(string location, string category, string item, int id, int? orderId)
