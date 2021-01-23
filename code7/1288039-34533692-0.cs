    using IenumerableAsClassVariable.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.Caching;
    
    namespace IenumerableAsClassVariable.Controllers
    {
        // This is the helper class & function used to determine if the IEnumerable is null or empty
        public static class CustomHelpers
        {
            public static string IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
            {
                if (enumerable == null)
                    return "Null";
                else
                    return "Not Null";
            }
        }
        
        public class CourseListsController : Controller
        {
            private CreditSlipLogContext db = new CreditSlipLogContext();   
    
            // This this the "index" query that is called by the Index 
            // and can be called by any other methods in this controller that I choose.
            private IEnumerable<CourseList> GetIndexQuery()
            {   
                using (var dbc = new CreditSlipLogContext())
                {
                    return  db.CourseLists.AsEnumerable();
                }
                
            }
    
            // GET: CourseLists
            public ActionResult Index()
            {
                var data = GetIndexQuery();
                Debug.WriteLine("-----");
                Debug.WriteLine("Begin Index test *****");
                Debug.WriteLine("Is data Null? " + CustomHelpers.IsNullOrEmpty(data));                        
                Debug.WriteLine("End Index test *****");           
    
                return View(db.CourseLists.ToList());
            }
    
            public ActionResult ClickedFromIndexPageLink()
            {
                var data = GetIndexQuery();
                Debug.WriteLine("-----");
                Debug.WriteLine("Begin Index test *****");
                Debug.WriteLine("Is data Null? " + CustomHelpers.IsNullOrEmpty(data));
                Debug.WriteLine("End Index test *****");  
    
                ViewBag.IsDataNull = CustomHelpers.IsNullOrEmpty(data);
    
                return View();
            }
    
            #region OtherCrudActionResultsAreHidden
            #endregion
    
        }
    }
