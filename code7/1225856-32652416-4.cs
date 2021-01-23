    public class Candy
    {
        public MyColor Color { get; set; }
        public string Name { get; set; }
        private MyColor _selectedColor;
        public MyColor SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                Color = value;
            }
        }
        private string _enteredName;
        public string EnteredName
        {
            get { return _enteredName; }
            set
            {
                _enteredName = value;
                Name = value;
            }
        }
    }
