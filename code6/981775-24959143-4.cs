    public class BaseController : Controller
    {
        public BaseModel Initialize(BaseModel model)
        {
            model.Title = "Title";
            model.Description = "Desc";
            return model;
        }
    }
