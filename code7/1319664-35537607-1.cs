	public class ContactViewHolder : V7.RecyclerView.ViewHolder, View.IOnClickListener
	{
		public TextView ContactNameTextView { get; set; }
		public TextView ContactPhoneTextView { get; set; }
		public TextView ContactIntialsTextView { get; set; }
		public Contact Contact { get; set; }
		private WeakReference _adapter;
		public ContactsAdapter Adapter
		{
			get { return (ContactsAdapter)_adapter.Target; }
			set { _adapter = new WeakReference(value); }
		}
		public ContactViewHolder(View view)
			: base(view)
		{
			GetUI(view);
			view.SetOnClickListener(this);
		}
		private void GetUI(View view)
		{
			ContactNameTextView = view.FindViewById<TextView>(Resource.Id.ContactName);
			ContactPhoneTextView = view.FindViewById<TextView>(Resource.Id.ContactPhone);
			ContactIntialsTextView = view.FindViewById<TextView>(Resource.Id.ContactInitialsTextView);
		}
		public void BindUI(Contact contact)
		{
			Contact = contact;
			ContactNameTextView.Text = contact.ContactName;
			ContactPhoneTextView.Text = contact.Phone1;
			ContactIntialsTextView.Text = contact.Initials;
		}
		public void OnClick(View v)
		{
			Adapter.OnItemClick(this);
		}
	}
