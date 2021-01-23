    public class ExtendedAutoCompleteBox : AutoCompleteBox
    {
        private ListBox _listBox;
        public override void OnApplyTemplate()
        {
            _listBox = GetTemplateChild("Selector") as ListBox;
        }
        public void ShowAllOptions()
        {
            var selectedItem = SelectedItem;
            Text = "";
            IsDropDownOpen = true;
            _listBox.SelectedItem = selectedItem;
            UpdateLayout();
            _listBox.ScrollIntoView(selectedItem);
        }
    }
