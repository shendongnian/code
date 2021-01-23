    public class HomeController : Controller {
		static List<Car> carList = new List<Car>();
		public ActionResult Index() {
			if (carList.Count() == 0 )
				carList = createCarList();
			return View(new Car(99,"",""));
        }
        // call the modal dialog
        public ActionResult CarSelection() {
            return PartialView("_CarSelection", carList);
        }
        [HttpPost]
        // called by the modal dialog to pass the value the user selected
        public ActionResult CarSelected(int carId) {
			Car theCar = carList.ElementAt(carId);
			return View("Index", theCar);
        }
        // some data entries
		private List<Car> createCarList () {
		    carList.Add(new Car(0, "", "Fork Lift"));
			carList.Add(new Car(1, "B-AX 54", "Fordson Power Major"));
			carList.Add(new Car(2, "B-RX 837", "Unimog"));
			carList.Add(new Car(3, "", "Sidelift Crane"));
			carList.Add(new Car(4, "", "Bobcat Excavator"));
			carList.Add(new Car(5, "K-O 38", "Cat Track Loader"));
			carList.Add(new Car(6, "CW-X 2734", "Snowplow"));
			carList.Add(new Car(7, "KI-MR 74", "Toyota Pickup"));
			return carList;
		}
	}
