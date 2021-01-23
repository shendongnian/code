     public class ContactsAdapter : BaseAdapter
    {
        Activity activity;
        List<Contact> contactList;
        public ContactsAdapter(Activity activity)
        {
            this.activity = activity;
            FillContacts();
        }
        void FillContacts()
        {
            var uri = calllog.ContentUri;
            //var uri = ContactsContract.Contacts.ContentUri;
            string[] projection = {
                calllog.Number,
                calllog.Date,
                calllog.Duration,
                calllog.Type,
                calllog.CachedName,
                calllog.CachedPhotoId
            };
            // CursorLoader introduced in Honeycomb (3.0, API11)
            var loader = new CursorLoader(activity, uri, projection, null, null, null);
            var cursor = (ICursor)loader.LoadInBackground();
            contactList = new List<Contact>();
            if (cursor.MoveToFirst())
            {
                do
                {
                    contactList.Add(new Contact
                    {
                        Number = cursor.GetString(cursor.GetColumnIndex(projection[0])),
                        Date = cursor.GetLong(cursor.GetColumnIndex(projection[1])),
                        Duration = cursor.GetString(cursor.GetColumnIndex(projection[2])),
                        Type = cursor.GetString(cursor.GetColumnIndex(projection[3])),
                        Name = cursor.GetString(cursor.GetColumnIndex(projection[4])),
                        PhotoId = cursor.GetString(cursor.GetColumnIndex(projection[5]))
                    });
                } while (cursor.MoveToNext());
            }
        }
        public override int Count
        {
            get { return contactList.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return 0;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.CallLogItems, parent, false);
            var callNum = view.FindViewById<TextView>(Resource.Id.NumTxtVw);
            var callType = view.FindViewById<ImageView>(Resource.Id.TypeIndicatImgVw);
            var calldate = view.FindViewById<TextView>(Resource.Id.CallTime);
            var name = view.FindViewById<TextView>(Resource.Id.CallerNameTxtVw);
            var contactImg = view.FindViewById<ImageView>(Resource.Id.ContactImgVw);
            callNum.Text = contactList[position].Number;
            
            calldate.Text = ConvertToDate.ToDateTimeFromEpoch(contactList[position].Date).ToString();// ToDateTimeFromEpoch(contactList[position].Date).ToString();
            if (string.IsNullOrWhiteSpace(contactList[position].Name))
            {
                name.Text = "Unkown";
            }
            else
            {
                name.Text = contactList[position].Name;
            }
            if (contactList[position].PhotoId == null)
            {
                contactImg = view.FindViewById<ImageView>(Resource.Id.ContactImgVw);
                contactImg.SetImageResource(Resource.Drawable.contactimg);
            }
            else
            {
                contactImg = view.FindViewById<ImageView>(Resource.Id.ContactImgVw);
                contactImg.SetImageResource(Resource.Drawable.contactimg);
            }
            if (contactList[position].Type == "1")
            {
                var contactImage = view.FindViewById<ImageView>(Resource.Id.TypeIndicatImgVw);
                contactImage.SetImageResource(Resource.Drawable.incoming);
            }
            else
            if (contactList[position].Type == "2")
            {
                var contactImage = view.FindViewById<ImageView>(Resource.Id.TypeIndicatImgVw);
                contactImage.SetImageResource(Resource.Drawable.outgoing);
            }
            else
            if (contactList[position].Type == "3")
            {
                var contactImage = view.FindViewById<ImageView>(Resource.Id.TypeIndicatImgVw);
                contactImage.SetImageResource(Resource.Drawable.misssedcall);
            }
            else
            if (contactList[position].Type == "4")
            {
                var contactImage = view.FindViewById<ImageView>(Resource.Id.TypeIndicatImgVw);
                contactImage.SetImageResource(Resource.Drawable.voicemail);
            }
            else
            if (contactList[position].Type == "5")
            {
                var contactImage = view.FindViewById<ImageView>(Resource.Id.TypeIndicatImgVw);
                contactImage.SetImageResource(Resource.Drawable.reject);
            }
            else
            if (contactList[position].Type == "6")
            {
                var contactImage = view.FindViewById<ImageView>(Resource.Id.TypeIndicatImgVw);
                contactImage.SetImageResource(Resource.Drawable.blocked);
            }
            return view;
        }
    }
