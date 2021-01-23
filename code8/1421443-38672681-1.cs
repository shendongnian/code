    [Controller]
    public abstract class ApiController
    {
        [ActionContext]
        public ActionContext ActionContext { get; set; }
    }
