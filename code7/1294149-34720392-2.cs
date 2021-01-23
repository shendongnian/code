    public interface IScheduleDetailsCollectionHolder
    {
        void AddElement(LibraryData data);
    }
    public class FirstClass : IScheduleDetailsCollectionHolder
    {
        private ObservableCollection<LibraryData> scheduleDetails;
        private void manageLayout_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ...
            scheduleDetail = assetListClass.GetScheduleDetail(xmlScheduleDetail);
            scheduleDetails = new ObservableCollection<LibraryData>(scheduleDetail);
            ManageLayout manageLayoutWin = new ManageLayout();
            this.Close();
            manageLayoutWin.Show();
            manageLayoutWin.ManageLayout_GridView.ItemsSource = scheduleDetails;
            ...
         }
         public void AddElement(LibraryData data)
         {
             scheduleDetails.Add(data);
         }
    }
    public class AnotherClass
    {
        private readonly IScheduleDetailsCollectionHolder collectionHolder;
        
        public AnotherClass(IScheduleDetailsCollectionHolder collectionHolder)
        {
            this.collectionHolder = collectionHolder;
        }
        public void AddElement()
        {
            var newElement = GetNewElement(); // creates element that will be add to the collection
            collectionHolder.AddElement(newElement);
        }
    }
