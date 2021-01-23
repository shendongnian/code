    public class PersonModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
    
            int id = Convert.ToInt32(request.QueryString["id"]);
    		string name = request.QueryString["name"];
    		int age = Convert.ToInt32(request.QueryString["age"]);
    		// other properties
            
            return new Person { Id = id, Name = name, Age = age };
        }
    }
