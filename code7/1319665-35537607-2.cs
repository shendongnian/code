	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_contacts = Contact.GetAllContacts();
		_adapter = new ContactsAdapter(_contacts);
		_adapter.ItemClick += ContactSelected;
	}
	public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		var view = inflater.Inflate(Resource.Layout.ContactsFragment, container, false);
		var layoutManager = new V7.LinearLayoutManager(this.Activity) { Orientation = V7.LinearLayoutManager.Vertical };
		_contactsView = view.FindViewById<V7.RecyclerView>(Resource.Id.ContactList);
		_contactsView.SetAdapter(_adapter);
		_contactsView.HasFixedSize = true;
		_contactsView.SetLayoutManager(layoutManager);
		return view;
	}
	private void ContactSelected (object sender, EventArgs e)
	{
		var holder = (ContactViewHolder)sender;
		var detailFragment = new ContactDetailsFragment(holder.Contact);
		MainActivity.ShowFragment(detailFragment);
	}
