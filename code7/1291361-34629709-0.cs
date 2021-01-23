    public ActionResult Index()
    {
        var user = unitOfWork.UsersRepository.GetById(1); // unitOfWork is dependency injected using Unity or Ninject or some other framework
        return View(user);
    }
