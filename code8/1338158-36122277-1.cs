    [HttpPost]
    public JsonResult doesCnicExist(string cnic, int id)
    {
        return Json(IsUnique(cnic, id));
    }
    private bool IsUnique(string cnic, int id)
    {
      if (id == 0) // its a new object
      {
        return !hc.employee.Any(x => x.cnic == cnic);
      }
      else // its an existing object so exclude existing objects with the id
      {
        return !hc.employee.Any(x => x.cnic == cnic && x.id != id);
      }
    }
