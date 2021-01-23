    public class FirstClass
    {
        public ObservableCollection<LibraryData> ScheduleDetails { get; private set; }
        private void manageLayout_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ...
            scheduleDetail = assetListClass.GetScheduleDetail(xmlScheduleDetail);
            ScheduleDetails = new ObservableCollection<LibraryData>(scheduleDetail);
            ManageLayout manageLayoutWin = new ManageLayout();
            this.Close();
            manageLayoutWin.Show();
            manageLayoutWin.ManageLayout_GridView.ItemsSource = ScheduleDetails;
            ...
         }
    }
