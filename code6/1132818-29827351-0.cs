    public class TimeModelBinder:DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, 
                                         ModelBindingContext bindingContext)
        {
            var hour = controllerContext.HttpContext.Request["hours"];
            var minutes = controllerContext.HttpContext.Request["minutes"];
            var time = new TimeSpan(int.Parse(Hour), int.Parse(minutes), 0);
            return return time;
        }
    }
