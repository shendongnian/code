    public class ColorsViewModel
    {
        public ObservableCollection<string> Colors { get; private set; }
        private string _selectedColor;
        public string SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                MessageBox.Show("Selected Color: " + value); //message box here to show the code is actually working.
            }
        }
        //... More code here in a moment
    }
