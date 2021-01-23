    [HttpPost]
    public ActionResult [ActionName] (int id)
    {
    .....
    employeeRepository.Save(employee);
    return RedirectToAction("Summary", new {id});
    }
