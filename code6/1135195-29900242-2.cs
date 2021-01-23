    class dialog_SignUp:DialogFragment
     {
        private Button mBtnSignUp;
        private EditText mFirstName;
        private EditText mEmail;
        private EditText mPassword;
        String parameter="";
        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;
        public dialog_SignUp(String parameterIn){
           parameter=parameterIn;
        }
        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView (inflater, container, savedInstanceState);
            var view = inflater.Inflate (Resource.Layout.dialog_sign_up, container, false);
            mBtnSignUp = view.FindViewById<Button> (Resource.Id.btnDialogEmail);
            mFirstName = view.FindViewById<EditText> (Resource.Id.txtFirstName);
            mFirstName.setText(parameter);
            mEmail = view.FindViewById<EditText> (Resource.Id.txtEmail);
            mPassword = view.FindViewById<EditText> (Resource.Id.txtPassword);
            mBtnSignUp.Click += mBtnSignUp_Click;
            return view;
        }
