    public class MyController
    {
        private UserBLL _userBll;
        public MyController(UserBLL userBll)
        {
            _userBll = userBll;
        }
        [HttpPost]
        public ActionResult Address(UserAddress model)
        {
            if(userBll.IsCityCodeValid(model.CityCode))
            {
                //do whatever
            }
            return View();//modelState already has errors in it so it will display in the view
        }
    }
