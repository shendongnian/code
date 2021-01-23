    class Error : DialogFragment
    {
        public string getErrorMsg { get; set; } // this gets the message
        
       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Error, container, false);
            TextView text = view.FindViewById<TextView>(Resource.Id.txtError);
            text.Text = getErrorMsg; //here the message is set to the TextView
            return view;
        }
    }
