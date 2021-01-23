    public class MenuTreeViewModel
    {
         public ICommand SelectedValueUpdated { get; set; }
         public MenuTreeViewModel()
         {
              SelectedValueUpdated = new SelectedValueUpdated(this);
         }
    }
