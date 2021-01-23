    public abstract class DbContextController : Controller{
        public AppDbContext  DB { get; private set;}
        public DbContextController(){
            DB = new AppDbContext();
        }
        protected override void OnDisposing(bool disposing){
            DB.Dispose();
        }
    }
