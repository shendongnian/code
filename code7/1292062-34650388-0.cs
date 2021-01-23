    public ActionResult SomeAction()
    {
        var vm = new SomeViewModel();
    
        vm.Countries = CountriesList.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    
        return View(vm);
    }
    
    public class SomeViewModel
    {
        public IEnumerable<SelectListItem> Countries {get;set;}
    
        public int SelectedCountryId {get;set;}
    }
