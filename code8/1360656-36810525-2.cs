    class Base_ViewModel : BasePropertyChanged
    {
        
        private List<ExamineExamplesDataGridItem> _items;
        public List<ExamineExamplesDataGridItem> items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged("items"); }
        }
        public Base_ViewModel()
        {
            items = new List<ExamineExamplesDataGridItem>();
            items.Add(new ExamineExamplesDataGridItem() { Coll1 = "Row 1 Col 1", Coll2 = "Row 1 Col 2" });
            items.Add(new ExamineExamplesDataGridItem() { Coll1 = "Row 2 Col 1", Coll2 = "Row 2 Col 2" });
            items.Add(new ExamineExamplesDataGridItem() { Coll1 = "Row 3 Col 1", Coll2 = "Row 3 Col 2" });
        }
    }
