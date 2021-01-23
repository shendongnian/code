    [Route("college/{courseId}/{classId?}")]
    public void ActionResult example1(string courseId, string classId) {
        // Do classId null check if necessary
        return View();
    }
