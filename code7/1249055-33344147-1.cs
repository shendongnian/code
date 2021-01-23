    public class HomeController : ControllerBase 
    {
        public JsonResult UpdateData(...) { 
            useOverriddenMethod = false;
            return this.Json(...); // I need to prevent this method from being overriden
        }
    
        public JsonResult UpdateResult(...) { 
            return this.Json(...); // this (and the other ones) can use the base method.
        }
    }
