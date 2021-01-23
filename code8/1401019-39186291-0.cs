    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    namespace Custor.Controllers.radiobuttontest
    {
        public class radiobuttontestController : Controller
        {
            [HttpGet]
            public ActionResult Index()
            {
                // instantiating the POCO class
                Model1 TestData = new Model1();
                // Populating the instantiated class
                TestData.ID = 1;
                TestData.Name = "IncomingName";
                TestData.SimpleCollection = new List<string>() { "raz", "dwa", "trzy" };
                TestData.Example = new List<ComplexClass>() {
                    new ComplexClass(){ Number=500, Word="piecset", IsSelected=true},
                    new ComplexClass(){ Number=1000, Word="tysiąc", IsSelected=false},
                    new ComplexClass(){ Number=100, Word="sto", IsSelected=false}
                };
                return View("Index",TestData);
            }
    
            // You can experiment with the binding here, to leave out or include as many fields as you like from the data model bound to the ActionResult
            [HttpPost]
            public ActionResult Index([Bind(Include = "ID,Name,Example,SimpleCollection")] Model1 IncomingSelection)
            {
                string selectedname = IncomingSelection.Name;  // put a breakpoint on this line, to study the Debug > Windows > Locals output, and observe that the values are successfully posted.
                return View("Index", IncomingSelection); // post the incoming data right back to the view again
            }
        }
    
        public class Model1
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<ComplexClass> Example { get; set; }
            public List<string> SimpleCollection { get; set; }
        }
        public class ComplexClass
        {
            public int Number { get; set; }
            public string Word { get; set; }
            public Nullable<bool> IsSelected { get; set; }
        }
    }
