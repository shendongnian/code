    public abstract class BaseController : Controller {
        private MyDbContext _db;
        protected MyDbContext DBContext {
            get { return _db ?? ( _db = new MyDbContext() ); }
        }
        protected void PopulateViewModel(ViewModel vm) {
            vm.Bla = this.DBContext.GetBla();
            vm.Page = this.DBContext.UniqueLogic.ToList();
        }
        
        protected override void Dispose(bool disposing) {
            if (disposing && this._db != null) {
                this._db.Dispose();
                this._db = null;
            }
            base.Dispose(disposing);
        }
    }
