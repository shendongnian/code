    public class StudentViewModel
    {
        public ObservableCollection<student> StudentList { get; set; }
        public ICollectionView StudentView { get; set; }
        public StudentViewModel()
        {
            StudentList= new ObservableCollection<student>();
            StudentView = new CollectionView(StudentList);
            StudentView.Filter = Filter;
            StudentView.SortDescriptions.Add(new SortDescription("Name",ListSortDirection.Ascending));
        }
        private bool Filter(object obj)
        {
            return true;
        }
    }
    <DataGrid Name="gridStudents" ItemsSource="{Binding StudentView}" ... />
