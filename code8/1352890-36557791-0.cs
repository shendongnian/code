    class ListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
            }
        } 
    }
