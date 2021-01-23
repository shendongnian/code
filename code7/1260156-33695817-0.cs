    public ActionResult PostBread(RestaurantViewModel viewModelPost, Bread bread)
    public ActionResult PostMilk(RestaurantViewModel viewModelPost, Milk milk)
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class FoodSelectorAttribute : ActionNameSelectorAttribute
    {
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            ... check if provided parameters contains bread/milk
