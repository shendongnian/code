    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    
        SetContentView(Resource.Layout.MainChat);
    
        var client = Nav.GetAndRemoveParameter<MyClient>(Intent);
    
        var vm = VmLocator.Chat;
        vm.InitClient(client);
        vm.InitModel();
    
        var contactsList = FindViewById<ListView>(Resource.Id.lvContacts);
    
        contactsList.Adapter = vm.OtherParticipants.GetAdapter(ContactsListViewTemplate);
    }
    
    private View ContactsListViewTemplate(int position, ObservableKeyValuePair<string, string> participant,
        View convertView)
    {
        var view = convertView ?? LayoutInflater.Inflate(Resource.Layout.ParticipantsListItem, null);
    
        var firstName = view.FindViewById<TextView>(Resource.Id.tvParticipantName);
    
        firstName.Text = participant.Value;
    
        return view;
    }
