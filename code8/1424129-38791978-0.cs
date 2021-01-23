    public partial class EditField : UserControl
    {
        #region DataGridSelectedItems
        public static DependencyProperty selectedList = 
            DependencyProperty.Register("DataGridSelectedItems", typeof(OC<AudioFile>), typeof(EditField));
        public OC<AudioFile> DataGridSelectedItems
        {
            get { return (OC<AudioFile>)GetValue(selectedList); }
            set { SetValue(selectedList, value); }
        }
        #endregion
        #region DataGridItemsSource
        public static DependencyProperty datagriditemsource =
            DependencyProperty.Register("DataGridItemsSource", typeof(OC<AudioFile>), typeof(EditField));
        public OC<AudioFile> DataGridItemsSource
        {
            get { return (OC<AudioFile>)GetValue(datagriditemsource); }
            set { SetValue(datagriditemsource, value); }
        }
        #endregion
        public EditField()
        {
            InitializeComponent();
    }
        private void Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OC<AudioFile> l = new OC<AudioFile>();
            DataGridSelectedItems.Clear();
            foreach (AudioFile i in Collection.SelectedItems) //'Collection' is a DataGrid
                 l.Add(DataGridItemsSource.Where(x => x.Songcode == i.Songcode || x.FilePath == i.FilePath).First());
            If (l.Count > 0)
                DataGridSelectedItems = l;
        }
    }
