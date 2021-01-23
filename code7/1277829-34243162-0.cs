    public class ViewModel
    {
        public int? SelectedItem { get; set; }
        public int[] MyItems { get; set; }
    }
    public class MyController : Controller
    {
        [HttpGet]
        public ActionResult MyAction(int? selectedItem = null)
        {
            // Here you create your ViewModel and pass it to the View Engine to render
            ViewModel viewModel = new ViewModel()
            {
                SelectedItem = selectedItem,
                MyItems = { 1, 2, 3, 4, 5, 6, 7, 8 },
            };
            return View(viewModel);
        }
    }
