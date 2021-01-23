    public ActionResult Details(int id, int? shelveId)
    {
      var vm = new BookViewModel{ Id=id };
      // to do : Get book entity and map to view model.(Except the ShelveId property)
      if(shelveId!=null)
      {
        vm.ShelveID=shelveId;
      }
      return View(vm);
    }
