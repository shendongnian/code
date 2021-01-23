        public class MyController: Controller
        {
         public MyController(UserControlHelper helper)
         {
          ViewBag.FullName = helper.GetUserData(UserId, "Name");
         }
        }
