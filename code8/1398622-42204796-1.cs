    public class MainViewModel
    {
        public ObservableCollection<Plugin.Contacts.Abstractions.Contact> Contacts { get; private set; }
        public MainViewModel()
        {
            this.Contacts = new ObservableCollection<Plugin.Contacts.Abstractions.Contact>();
            ReloadContacts();
        }
        public void ReloadContacts()
        {
            // Device may request user permission to get contacts access.
            var hasPermission = CrossContacts.Current.RequestPermission()
                .GetAwaiter()
                .GetResult();
            if (hasPermission)
            {
                this.Contacts.Clear();
                List<Plugin.Contacts.Abstractions.Contact> contacts = null;
                CrossContacts.Current.PreferContactAggregation = false;
                if (CrossContacts.Current.Contacts == null)
                {
                    return;
                }
                contacts = CrossContacts.Current.Contacts.ToList();
                foreach (var contact in contacts)
                {
                    this.Contacts.Add(contact);
                }
            }
        }
    }
