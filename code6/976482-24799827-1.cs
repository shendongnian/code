    //Don't create this class on the controller! This is only as an example.
    public class FilterViewModel {
       public bool Status {get; set;}
       public IEnumerable<SelectListItem> statusDropDown {get; set;}
    }
    var myViewModel = new FilterViewModel();
    myViewModel.statusDropDown = new List<SelectListItem>(){
         new SelectListItem
         {
            Value = "Yes",
            Text = "Yes",
            Selected = yourFilter.FilterStatus
         },
         new SelectListItem
         {
            Value = "No",
            Text = "No",
            Selected = yourFilter.FilterStatus
         }
    };
    return View(myViewModel);
