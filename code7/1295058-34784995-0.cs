    public class ViewModel : PropertyChangedBase, IWeakEventListener
    {
        private List<User> users = new List<User>();
        private bool suspendListening;
    
        public ViewModel()
        {
            users.Add(CreateUser(1, "John Doe"));
            users.Add(CreateUser(2, "Jane Doe"));
            users.Add(CreateUser(3, "Sammy Doe"));
            users.Add(CreateUser(3, "Abhi"));
            users.Add(CreateUser(3, "Amy"));
            users.Add(CreateUser(3, "Arin"));
            users.Add(CreateUser(3, "Kate"));
            users.Add(CreateUser(3, "Kane"));
        }
    
        public IList<User> Users
        {
            get
            {
                return users;
            }
        }
    
        private User CreateUser(int id, string name)
        {
            User user = new User();
            user.Id = id;
            user.Name = name;
    
            PropertyChangedEventManager.AddListener(user, this, String.Empty);
    
            return user;
        }
    
        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(PropertyChangedEventManager))
            {
                PropertyChangedEventArgs propertyChangedEventArgs = e as PropertyChangedEventArgs;
                User changedUser = sender as User;
                if (propertyChangedEventArgs.PropertyName == "IsSelected" && changedUser.IsSelected && !suspendListening)
                {
                    try
                    {
                        suspendListening = true;
                        foreach (User user in users)
                        {
                            if (user.Id == changedUser.Id)
                            {
                                user.IsSelected = true;
                            }
                        }
                    }
                    finally
                    {
                        suspendListening = false;
                    }
                }
    
                return true;
            }
    
            return false;
        }
    }
