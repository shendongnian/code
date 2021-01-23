    public class MyViewModel
    {
       List<DropDownA> dropDownA {get;set;}
       public IEnumerable<SelectListItem> ddaSLI { get { return new SelectList(dropDownA, "id", "value"); } }
    }
