    class Program
    {
        static void Main(string[] args)
        {
            RoleService roleService = new RoleService();
        }
    }
    class RoleService : GenericLookupModelDataService<tblkp_Role, RoleViewModel> 
    { }
    public abstract class GenericLookupModelDataService<TModel, TViewModel> : object
        where TModel : GenericLookupModel, new()
        where TViewModel : GenericLookupViewModel, new()
    { }
    public abstract class GenericLookupViewModel { }
    public abstract class GenericLookupModel { }
    public class RoleViewModel : GenericLookupViewModel { }
    public partial class tblkp_Role : GenericLookupModel 
    {
    }
    public partial class tblkp_Role
    {
        public tblkp_Role()
        {
        }
    }
