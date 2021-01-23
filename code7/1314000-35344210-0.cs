       public class IndexViewModel
       {
          public bool HasPassword { get; set; }
          public string PhoneNumber { get; set; }
          public bool TwoFactor { get; set; }
          public bool BrowserRemembered { get; set; }
        }
        
        //...........
        
        Expression<Func<IndexViewModel, bool>> ex =
        System.Linq.Dynamic.DynamicExpression.ParseLambda<IndexViewModel, bool>("TwoFactor");
            var model = new ReactJs.NET.Models.IndexViewModel() { TwoFactor = true };
            var res = ex.Compile()(model);
            // res == true
            System.Diagnostics.Debug.Assert(res);
