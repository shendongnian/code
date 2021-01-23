    public class ViewModel
    {
        public string SenderAddress { get; set; }
        public string SenderState { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string RequestDate { get; set; }
        public string CargoHeight { get; set; }
        public string CargoLenght { get; set; }
        public string CargoQuantity { get; set; }
        public string PaymentType { get; set; }
        public string CargoWidth { get; set; }
        public string CargoWeight { get; set; }
    }
    [HttpPost]
    public ActionResult Index(ViewModel viewModel)
    {
        RouteDetailRepository rdr = new RouteDetailRepository();
        int routeId = rdr.getRouteId(viewModel.SenderState, viewModel.ReceiverState);
        List<RoutesDetail> companyList = rdr.getRouteDetail(routeId);
        if (companyList == null)
        {
            return JavaScript("Seçilen Güzergaha Sistemde Kayıtlı Olan Hiç Bir Kargo Firması Servis Yapmamaktadır.");
        }
        return Json(new { status = "success" });
    }
