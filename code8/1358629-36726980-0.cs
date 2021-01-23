    public ActionResult Details(int id)
    {
      var clientList =new List<ClientProjectViewModel> 
      //load clients and it's projects
      clientList.Add(new ClientProjectViewModel { Clientid=1, ClientName="A", 
                                     projects=new List<ProjectViewModel> {
                                   new ProjectViewModel { Id=1, Title="ProjectforThisclien1"}
      };    
      return View(clientList)
    }
