    public class ControllerContextClonable
    { 
        public static List<ControllerContext> ToList(HomeController context)
        {
            return new List<ControllerContext> { context.ControllerContext};
        }
    }
