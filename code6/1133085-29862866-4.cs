    public class HomeController : Controller
    {
        // One global subscription for all the controller.
        static HomeController()
        {
            // ITableRowRepository incapsulates SqlDependencyEx usage.
            var repo = (ITableRowRepository)DependencyResolver.Current
                               .GetService(typeof(ITableRowRepository));
            // One global subscription.
            repo.TableChanged += RepoTableChanged;
        }
        // Actions here.
        private static void RepoTableChanged(object sender, TableChangedEventArgs e)
        {
            // Clients notification here.
        }
    } 
