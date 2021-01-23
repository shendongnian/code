    public class ViewModel {
        private readonly List<PortionFood> _foods;
        [Display(Name = "Pick a portion")]
        public int SelectedFoodItem { get; set; }
        public IEnumerable<SelectListItem> FoodPortionItems
        {
            get { return new SelectList(_foods, "Id", "Name"); }
        }
    }
    public class PortionFood {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //In your Razor View:
    @Html.LabelFor(m => m.SelectedFoodItem)
    @Html.DropDownListFor(m => m.SelectedFoodItem, Model.FoodPortionItems)
