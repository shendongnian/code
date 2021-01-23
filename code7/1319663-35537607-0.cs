	public class ContactsAdapter : V7.RecyclerView.Adapter
	{
		private List<Contact> _contacts;
		public event EventHandler ItemClick;
		public void OnItemClick(ContactViewHolder holder)
		{
			if (ItemClick != null)
			{
				ItemClick(holder, EventArgs.Empty);
			}
		}
		public ContactsAdapter(List<Contact> contacts)
			: base()
		{
			_contacts = contacts;
		}
		public override void OnBindViewHolder(V7.RecyclerView.ViewHolder holder, int position)
		{
			var contactHolder = (ContactViewHolder)holder;
			contactHolder.BindUI(_contacts[position]);
		}
		public override V7.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var view = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.ContactsListItem, parent, false);
			return new ContactViewHolder(view)
			{
				Adapter = this
			};
		}
		public override int ItemCount
		{
			get
			{
				return _contacts.Count;
			}
		}
	}
