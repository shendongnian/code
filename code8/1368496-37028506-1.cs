    public class FriendsViewModel : INotifyPropertyChanged
    {
        private Dispatcher _dispatcher;
        public FriendsViewModel()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            au = AuthSingleton.Instance.getAuthUser();
            //this comes from other window
            if (AuthSingleton.Instance.IsAuth == true) loadFriends();
        }
        public async void loadFriends()
        {
            ObservableCollection<Friend> friends = new ObservableCollection<Friend>();
            var response = await CommunicationWebServices.GetASM("171" + "/friends", au.token);
            var fh = JsonConvert.DeserializeObject<FriendsHandler>(response);
            foreach (var friend in fh.friends)
            {
                friends.Add(new Friend { name = friend.name, nickname = friend.nickname, date = friend.date });
            }
            Friends = friends;
            _dispatcher.Invoke(() => OnPropertyChanged("Friends");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        *** more code here I guess ****
    }
