    public class BaseController : Controller
    {
        public BaseModel Intialize(BaseModel model)
        {
            model.Title = "Title";
            model.Description = "Desc";
            return model;
        }
    }
