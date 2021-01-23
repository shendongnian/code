    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    public class MyController: Controller{    
        private readonly VariablesNeeded _variablesNeeded;
        public MyController(IOptions<VariablesNeeded> variablesNeeded) {
            _variablesNeeded= variablesNeeded.Value;
        }
        public ActionResult TestVariables() {
            return Content(_variablesNeeded.Foo1 + _variablesNeeded.Foo2);
        }
    }
