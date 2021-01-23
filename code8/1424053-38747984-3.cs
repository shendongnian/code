    public class DefaultController : Controller
    {
      private static readonly IEnumerable<string> personalizedSites = new[] { "companyA", "companyB" };
      private static readonly IEnumerable<string> actions = new[] { "index", "plan", "investing", "etc" };
    
      public ActionResult Index(string url)
      {
        string view;
        PersonalizedViewModel viewModel;
        if (string.IsNullOrWhiteSpace(url) || actions.Any(a => a.Equals(url, StringComparison.CurrentCultureIgnoreCase)))
        {
          view = url;
          viewModel = new PersonalizedViewModel("Default");
        }
        else if (personalizedSites.Any(s => s.Equals(url, StringComparison.CurrentCultureIgnoreCase)))
        {
          view = "index";
          viewModel = new PersonalizedViewModel(url);
        }
        else
        {
          return View("Error404");
        }
    
        return View(view, viewModel);
      }
    
      public ActionResult Plan(string url)
      {
        PersonalizedViewModel viewModel;
        if (string.IsNullOrWhiteSpace(url))
        {
          viewModel = new PersonalizedViewModel("Default");
        }
        else if (personalizedSites.Any(s => s.Equals(url, StringComparison.CurrentCultureIgnoreCase)))
        {
          viewModel = new PersonalizedViewModel(url);
        }
        else
        {
          return View("Error404");
        }
    
        return View(viewModel);
      }
    }
