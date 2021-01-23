    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
    var ctx = store.Context;
    var currentUser = manager.FindById(User.Identity.GetUserId());  
    pedido.Nombre = currentUser.Nombre;
