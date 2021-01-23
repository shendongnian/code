      private ObservableCollection<Order> _ordersCollection = new ObservableCollection<Order>()
        {
            new Order()
            {
                OrderId = "1",
                SelectedUserId = "2"
            } ,new Order()
            {
                OrderId = "2",
                SelectedUserId = "3"
            }
        };
        public ObservableCollection<Order> OrdersCollection
        {
            get
            {
                return _ordersCollection;
            }
            set
            {
                if (_ordersCollection == value)
                {
                    return;
                }
                _ordersCollection = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<User> _usersCollection = new ObservableCollection<User>()
        {
            new User()
            {
                UserId = "1",
                UserName = "Name1",
                CompanyName = "Company1"
            } ,new User()
            {
                UserId = "2",
                UserName = "Name2",
                CompanyName = "Company2"
            } ,new User()
            {
                UserId = "3",
                UserName = "Name3",
                CompanyName = "Company3"
            }
        };
        public ObservableCollection<User> UsersCollection
        {
            get
            {
                return _usersCollection;
            }
            set
            {
                if (_usersCollection == value)
                {
                    return;
                }
                _usersCollection = value;
                OnPropertyChanged();
            }
        }
