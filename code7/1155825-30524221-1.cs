    public class MyController
    {
        public ActionResult Index()
        {
            var data = _myRepository.GetYourData();
            var viewModel = new OrderDto()
            {
                UserName = data.UserName,
                NameSurname = data.NameSurname,
                Phone = data.Phone,
                CreateDate = data.CreateDate
            };
            return View(data)
        }
    }
