    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class RoomsViewModel : INotifyPropertyChanged
    {
        /* constructor goes here from previous code block */
        private ObservableCollection<AvailableRoomModel> availableRooms;
        public ObservableCollection<AvailableRoomModel> AvailableRooms
        {
            get { return availableRooms; }
            set { availableRooms = value; OnPropertyChanged(); }
        }
        private ObservableCollection<AvailableRoomModel> list;
        public ObservableCollection<AvailableRoomModel> List
        {
            get { return list; }
            set { list = value; OnPropertyChanged(); }
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
