        using radiotest.Models;
         using System;
         using System.Collections.Generic;
         using System.Linq;
         using System.Web;
         using System.Web.Mvc;
    
         namespace radiotest.Controllers
         {
            public class TestController : Controller
            {
       
                public ActionResu`enter code here`lt Index()
                {
                     SomeOrder se = new SomeOrder{ TypeDrink="3" };
                     return View(se);
                }
    
                [HttpPost]
                public ActionResult Index(SomeOrder model)
                {
                    //model.TypeDrink gives you selected radio button in HTTP POST
                    SomeOrder se = new SomeOrder {TypeDrink = model.TypeDrink };
                    return View(se);
                }
            }
         }
    
 
